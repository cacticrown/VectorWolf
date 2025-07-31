using Microsoft.Xna.Framework;

namespace VectorWolf.Graphics;

public static class RenderHelper
{
    public static void DrawRectangleOutline(Rectangle rect, Color color, int lineThickness)
    {
        // Top
        RenderContext.SpriteBatch.Draw(RenderContext.Pixel,
            new Rectangle(rect.Left, rect.Top, rect.Width, lineThickness), color);

        // Bottom
        RenderContext.SpriteBatch.Draw(RenderContext.Pixel,
            new Rectangle(rect.Left, rect.Bottom - lineThickness, rect.Width, lineThickness), color);

        // Left
        RenderContext.SpriteBatch.Draw(RenderContext.Pixel,
            new Rectangle(rect.Left, rect.Top + lineThickness, lineThickness, rect.Height - (2 * lineThickness)), color);

        // Right
        RenderContext.SpriteBatch.Draw(RenderContext.Pixel,
            new Rectangle(rect.Right - lineThickness, rect.Top + lineThickness, lineThickness, rect.Height - (2 * lineThickness)), color);
    }
}
