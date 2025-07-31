using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VectorWolf.Graphics;

namespace VectorWolf.Collisions;

public class RectangleCollider : Collider
{
    public Vector2 Size = Vector2.Zero;
    public Vector2 Offset = Vector2.Zero;

    public bool Collides(RectangleCollider other) => GetRectangle().Intersects(other.GetRectangle());

    public Rectangle GetRectangle()
    {
        return new Rectangle(
            (int)(Entity.Position.X + Offset.X),
            (int)(Entity.Position.Y + Offset.Y),
            (int)Size.X,
            (int)Size.Y
        );
    }
    public override void DebugDraw(int lineThickness = 2, float transparency = 0.5f)
    {
        var rect = GetRectangle();
        RenderHelper.DrawRectangleOutline(rect, Color.Red * transparency, lineThickness);
    }
}
