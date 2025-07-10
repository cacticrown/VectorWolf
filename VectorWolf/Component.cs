namespace VectorWolf;

public class Component
{
    public Entity Entity;
    public Scene Scene => Entity.Scene;

    public virtual void OnSceneStart()
    {

    }

    public virtual void OnSceneEnd()
    {

    }

    public virtual void OnDestroy()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Draw()
    {

    }
}
