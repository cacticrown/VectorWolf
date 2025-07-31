using System.Collections.Generic;

namespace VectorWolf.Collisions;

public class ColliderList : Collider
{
    public List<Collider> Colliders { get; private set; } = new List<Collider>();

    public ColliderList(params Collider[] colliders)
    {
        Colliders.AddRange(colliders);
    }

    public void Add(Collider collider)
    {
        if (collider != null && !Colliders.Contains(collider))
        {
            Colliders.Add(collider);
            collider.Entity = Entity;
        }
    }

    public void Remove(Collider collider)
    {
        if (collider != null && Colliders.Contains(collider))
        {
            Colliders.Remove(collider);
            collider.Entity = null;
        }
    }

    public bool Collide(ColliderList colliderList)
    {
        foreach (var colliderA in Colliders)
        {
            if (colliderA is not RectangleCollider rectA) continue;

            foreach (var colliderB in colliderList.Colliders)
            {
                if (colliderB is not RectangleCollider rectB) continue;

                if (rectA.CollideWith(rectB))
                    return true;
            }
        }

        return false;
    }
}
