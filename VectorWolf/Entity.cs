using Microsoft.Xna.Framework;
using System.Collections.Generic;
using VectorWolf.Components;

namespace VectorWolf;

public class Entity
{
    public int Id;
    public Scene Scene;

    public ComponentList Components = new ComponentList();

    public Vector2 Position = Vector2.Zero;
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

    public virtual void Draw()
    {
        foreach (IDraw update in Components.DrawComponents)
        {
            update.Draw();
        }
    }
}
