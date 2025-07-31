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

    public bool Collides(ColliderList colliderList)
    {
        foreach (var colliderA in Colliders)
        {
            if (colliderA is not RectangleCollider rectA) continue;

            foreach (var colliderB in colliderList.Colliders)
            {
                if (colliderB is not RectangleCollider rectB) continue;

                if (rectA.Collides(rectB))
                    return true;
            }
        }

        return false;
    }

    public bool Collide(RectangleCollider collider1)
    {
        foreach (var collider2 in Colliders)
        {
            if (collider1 is not RectangleCollider rectangleCollider) continue;

            if (collider1.Collides(rectangleCollider))
                return true;
        }
        return false;
    }

    public bool Collide(GridCollider gridCollider)
    {
        foreach (var collider in Colliders)
        {
            if (collider is RectangleCollider rectangleCollider)
            {
                if (gridCollider.Collides(rectangleCollider.GetRectangle()))
                    return true;
            }
        }
        return false;
    }

    public override void DebugDraw(int lineThickness = 2)
    {
        foreach(var collider in Colliders)
        {
            collider.DebugDraw(lineThickness);
        }
    }
}
