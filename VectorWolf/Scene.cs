using System.Collections.Generic;

namespace VectorWolf;

public class Scene
{
    public List<Entity> Entities = new List<Entity>();
    public Stack<int> FreeEntityIds = new Stack<int>();

    public SceneBuffer Buffer = new();

    public void AddEntity(Entity entity, params Component[] components)
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
        foreach(var component in components)
        {
            entity.AddComponent(component);
        }
    }

    public void DestroyEntity(Entity entity)
    {
        entity.OnSceneEnd();
        FreeEntityIds.Push(entity.Id);
        Entities.Remove(entity);    
    }

    public Entity GetEntity(int id)
    {
        foreach(var entity in Entities)
        {
            if (entity.Id == id)
            {
                return entity;
            }
        }

        return null;
    }

    public void Update()
    {
        Buffer.Clear();
        foreach(var entity in Entities)
        {
            if (entity != null)
            {
                entity.Update();
            }
        }
        foreach(Entity entity in Buffer.AddedEntities)
        {
            AddEntity(entity);
        }
        foreach(Entity entity in Buffer.RemovedEntities)
        {
            DestroyEntity(entity);   
        }
        foreach(var componentAddition in Buffer.AddedComponents)
        {
            componentAddition.Key.AddComponent(componentAddition.Value);
            componentAddition.Value.Entity = componentAddition.Key;
        }
        foreach (var componentRemoval in Buffer.RemovedComponents)
        {
            componentRemoval.Key.RemoveComponent(componentRemoval.Value);
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

    }

    public void FinishedInitializing()
    {
        foreach (var entity in Entities)
        {
            entity.OnSceneStart();
        }
    }

    public void LoadContent()
    {
        foreach( var entity in Entities)
        {
            entity.LoadContent();
        }
    }
}

public class SceneBuffer
{
    public List<Entity> AddedEntities = new List<Entity>();
    public List<Entity> RemovedEntities = new List<Entity>();
    public Dictionary<Entity, Component> AddedComponents = new Dictionary<Entity, Component>();
    public Dictionary<Entity, Component> RemovedComponents = new Dictionary<Entity, Component>();

    public void Clear()
    {
        AddedEntities.Clear();
        RemovedEntities.Clear();
    }

    public void AddEntity(Entity entity, params Component[] components)
    {
        AddedEntities.Add(entity);
        foreach (var component in components)
        {
            entity.AddComponent(component);
        }
    }

    public void DestroyEntity(Entity entity)
    {
        RemovedEntities.Add(entity);
    }

    public void AddComponent(Entity entity, params Component[] components)
    {
        foreach(var component in components)
        {
            AddedComponents.Add(entity, component);
        }
    }

    public void RemoveComponent<T>(Entity entity) where T : Component
    { 
        RemovedComponents.Add(entity, entity.GetComponent<T>());
    }
}