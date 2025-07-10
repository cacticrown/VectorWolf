using System.Collections.Generic;

namespace VectorWolf;

public class Entity
{
    public int Id;
    public Scene Scene;

    public List<Component> Components = new List<Component>();

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
        Components.RemoveAll(c => c is T);
    }

    public virtual void OnSceneStart()
    {
        Components.ForEach(component => component.OnSceneStart());
    }

    public virtual void OnSceneEnd()
    {
        Components.ForEach(component => component.OnSceneEnd());
    }

    public virtual void OnDestroy()
    {
        Components.ForEach(component => component.OnDestroy());
    }

    public virtual void Update()
    {
        Components.ForEach(component => component.Update());
    }

    public virtual void Draw()
    {
        Components.ForEach(component => component.Draw());
    }
}
