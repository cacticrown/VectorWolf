using System.Collections.Generic;

namespace VectorWolf;

public class Scene
{
    public List<Entity> Entities = new List<Entity>();
    public Stack<int> FreeEntityIds = new Stack<int>();

    public Entity AddEntity(Entity entity, params Component[] components)
    {
        if (FreeEntityIds.TryPop(out var result))
        {
            entity.Id = result;
        }
        else
        {
            entity.Id = Entities.Count;
        }
        entity.Scene = this;
        Entities.Add(entity);
        entity.Components.AddRange(components);
        return entity;
    }

    public void DestroyEntity(Entity entity)
    {
        entity.OnSceneEnd();
        FreeEntityIds.Push(entity.Id);
        Entities.Remove(entity);    
    }

    public Entity GetEntity(int id)
    {
        return Entities[id];
    }

    public void Update()
    {
        foreach(var entity in Entities)
        {
            if (entity != null)
            {
                entity.Update();
            }
        }
    }

    public void Draw()
    {
        foreach (var entity in Entities)
        {
            if (entity != null)
            {
                entity.Draw();
            }
        }
    }

    public void OnDestroy()
    {
        foreach (var entity in Entities)
        {
            entity.OnDestroy();
        }
    }

    public virtual void Initialize()
    {
        FinishedInitializing();
    }

    public void FinishedInitializing()
    {
        foreach (var entity in Entities)
        {
            entity.OnSceneStart();
        }
    }
}
