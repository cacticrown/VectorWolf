using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VectorWolf.Graphics;

namespace VectorWolf.Collisions;

public class RectangleCollider : Collider
{
    public Vector2 Size = Vector2.Zero;
    public Vector2 Offset = Vector2.Zero;

    public int DebugDrawThickness = 2;

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

    public override void DebugDraw()
    {
        var rect = GetRectangle();
        var sb = RenderContext.SpriteBatch;
        Texture2D pixel = RenderContext.Pixel;

        // Top
        sb.Draw(pixel, new Rectangle(rect.Left, rect.Top, rect.Width, DebugDrawThickness), Color.Red);
        // Bottom
        sb.Draw(pixel, new Rectangle(rect.Left, rect.Bottom - DebugDrawThickness, rect.Width, DebugDrawThickness), Color.Red);
        // Left
        sb.Draw(pixel, new Rectangle(rect.Left, rect.Top, DebugDrawThickness, rect.Height), Color.Red);
        // DebugDrawThickness
        sb.Draw(pixel, new Rectangle(rect.Right - DebugDrawThickness, rect.Top, DebugDrawThickness, rect.Height), Color.Red);
    }
}
