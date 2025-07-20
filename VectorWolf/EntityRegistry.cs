using System.Collections.Generic;
using System;

namespace VectorWolf;

public static class EntityRegistry
{
    private static readonly Dictionary<string, Func<Entity>> _factories = new();

    public static void Register<T>() where T : Entity, new()
    {
        var type = typeof(T);
        string name = type.Name;

        if (_factories.ContainsKey(name))
            throw new InvalidOperationException($"Entity type \"{name}\" is already registered.");

        _factories[name] = () => new T();
    }    
    
    public static void Register<T>(string name) where T : Entity, new()
    {
        var type = typeof(T);

        if (_factories.ContainsKey(name))
            throw new InvalidOperationException($"Entity type \"{name}\" is already registered.");

        _factories[name] = () => new T();
    }

    public static Entity Create(string name)
    {
        if (!_factories.TryGetValue(name, out var factory))
            throw new KeyNotFoundException($"No entity type registered with name \"{name}\"");

        return factory();
    }

    public static IEnumerable<string> GetRegisteredEntityTypes() => _factories.Keys;
}
