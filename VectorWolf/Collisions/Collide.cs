using Microsoft.Xna.Framework;
using System.Runtime.CompilerServices;

namespace VectorWolf.Collisions;

public static class Collide
{
    public static bool Check(ColliderList colliderList1, ColliderList colliderList2)
    {
        foreach (var collider1 in colliderList1.Colliders)
        {
            foreach (var collider2 in colliderList2.Colliders)
            {
                if (collider1 is RectangleCollider rect1 && collider2 is RectangleCollider rect2)
                {
                    if (Check(rect1, rect2))
                    {
                        return true;
                    }
                }
                else if (collider1 is RectangleCollider rect && collider2 is GridCollider grid)
                {
                    if (Check(rect, grid))
                    {
                        return true;
                    }
                }
                else if (collider1 is GridCollider gridcollider && collider2 is RectangleCollider rectangle)
                {
                    if (Check(rectangle, gridcollider))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    #region rectangle

    public static bool Check(RectangleCollider rectangleCollider1, RectangleCollider rectangleCollider2)
    {
        return rectangleCollider1.GetRectangle().Intersects(rectangleCollider2.GetRectangle());
    }

    public static bool Check(RectangleCollider rectangleCollider, GridCollider gridCollider)
    {
        Rectangle rect = rectangleCollider.GetRectangle();
        int startX = rect.Left / gridCollider.CellSize;
        int endX = (rect.Right - 1) / gridCollider.CellSize;
        int startY = rect.Top / gridCollider.CellSize;
        int endY = (rect.Bottom - 1) / gridCollider.CellSize;

        for (int y = startY; y <= endY; y++)
        {
            for (int x = startX; x <= endX; x++)
            {
                if (gridCollider.IsSolid(x, y))
                    return true;
            }
        }

        return false;
    }

    public static bool Check(RectangleCollider rectangleCollider, Vector2 point)
    {
        Rectangle rect = rectangleCollider.GetRectangle();
        return rect.Contains(point);
    }

    public static bool Check(RectangleCollider rectangleCollider, ColliderList colliderList)
    {
        foreach (var collider in colliderList.Colliders)
        {
            if (collider is RectangleCollider rectCollider)
            {
                if (Check(rectangleCollider, rectCollider))
                    return true;
            }
            if(collider is GridCollider gridCollider)
            {
                if (Check(rectangleCollider, gridCollider))
                    return true;
            }
        }
        return false;
    }

    #endregion
}
