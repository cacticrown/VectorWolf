using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VectorWolf.Components;

public class ComponentList : IEnumerable<Component>
{
    public List<Component> Components = new List<Component>();
    public List<IUpdate> UpdateComponents = new List<IUpdate>();
    public List<IDraw> DrawComponents = new List<IDraw>();

    public void Add(Component component)
    {
        Components.Add(component);
        if(component is IUpdate updateable)
            UpdateComponents.Add(updateable);
        if(component is IDraw drawable)
            DrawComponents.Add(drawable);
    }

    public void Remove(Component component)
    {
        Components.Remove(component);
        if (component is IUpdate updateable)
            UpdateComponents.Remove(updateable);
        if (component is IDraw drawable)
            DrawComponents.Remove(drawable);
    }

    public void Remove<T>() where T : Component
    {
        var component = Components.OfType<T>().FirstOrDefault();

        Components.Remove(component);

        if (component is IUpdate updateable)
            UpdateComponents.Remove(updateable);

        if (component is IDraw drawable)
            DrawComponents.Remove(drawable);
    }

    public T GetComponent<T>() where T : Component
    {
        return Components.OfType<T>().FirstOrDefault();
    }

    public IEnumerable<T> GetComponents<T>() where T : Component
    {
        return Components.OfType<T>();
    }

    public IEnumerator<Component> GetEnumerator()
    {
        return Components.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
