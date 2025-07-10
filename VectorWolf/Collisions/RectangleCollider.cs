using Microsoft.Xna.Framework;

using VectorWolf.Graphics;

namespace VectorWolf.Collisions;

public class RectangleCollider : Component
{
    public Vector2 Size = Vector2.Zero;
    public Vector2 Offset = Vector2.Zero;

    public bool CollideWith(RectangleCollider other) => GetRectangle().Intersects(other.GetRectangle());

    public Rectangle GetRectangle()
    {
        return new Rectangle(
            (int)(Entity.Position.X + Offset.X),
            (int)(Entity.Position.Y + Offset.Y),
            (int)Size.X,
            (int)Size.Y
        );
    }
}
