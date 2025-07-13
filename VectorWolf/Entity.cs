using Microsoft.Xna.Framework;
using VectorWolf.Components;

namespace VectorWolf;

public class Entity
{
    public int Id;
    public Scene Scene;
    public float Layer = 0;

    public ComponentList Components = new ComponentList();

    public Vector2 Position = Vector2.Zero;
    public Vector2 Scale = Vector2.One;
    public float Rotation = 0f;

    public void AddComponent(Component component)
    {
        component.Entity = this;
        Components.Add(component);
    }

    public void RemoveComponent(Component component)
    {
        Components.Remove(component);
    }

    public void RemoveComponent<T>() where T : Component
    {
        Components.Remove<T>();
    }

    public Component GetComponent<T>() where T : Component
    {
        return Components.GetComponent<T>();
    }

    public virtual void OnSceneStart()
    {
        foreach(var component in Components)
        {
            component.OnSceneStart();
        }
    }

    public virtual void OnSceneEnd()
    {
        foreach (var component in Components)
        {
            component.OnSceneEnd();
        }
    }

    public virtual void OnDestroy()
    {
        foreach (var component in Components)
        {
            component.OnDestroy();
        }
    }

    public virtual void Update()
    {
        foreach(IUpdate update in Components.UpdateComponents)
        {
            update.Update();
        }
    }

    public virtual void LoadContent()
    {
        foreach(Component component in Components)
        {
            component.LoadContent();
        }
    }

    public virtual void Draw()
    {
        foreach (IDraw update in Components.DrawComponents)
        {
            update.Draw();
        }
    }
}
