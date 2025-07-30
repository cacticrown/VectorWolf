using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using VectorWolf.Graphics;

namespace VectorWolf.Collisions
{
    public class GridCollider : Collider
    {
        public int CellSize { get; set; }
        public bool[,] CollisionGrid { get; private set; }

        public int Width => CollisionGrid.GetLength(0);
        public int Height => CollisionGrid.GetLength(1);

        public GridCollider(int width, int height, int cellSize)
        {
            CellSize = cellSize;
            CollisionGrid = new bool[width, height];
        }

        public void Set(int x, int y, bool solid)
        {
            if (!InBounds(x, y))
                throw new ArgumentOutOfRangeException("Coordinates are out of bounds of the collision grid.");

            CollisionGrid[x, y] = solid;
        }

        public bool IsSolid(int x, int y)
        {
            return InBounds(x,y) && CollisionGrid[x, y];
        }

        public bool Collides(Vector2 point)
        {
            int gridX = (int)(point.X / CellSize);
            int gridY = (int)(point.Y / CellSize);
            return IsSolid(gridX, gridY);
        }

        public bool Collides(Rectangle rect)
        {
            int startX = rect.Left / CellSize;
            int endX = (rect.Right - 1) / CellSize;
            int startY = rect.Top / CellSize;
            int endY = (rect.Bottom - 1) / CellSize;

            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    if (IsSolid(x, y))
                        return true;
                }
            }

            return false;
        }

        private bool InBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x < Width && y < Height;
        }

        public override void DebugDraw()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var rect = new Rectangle(x * CellSize, y * CellSize, CellSize, CellSize);

                    if (CollisionGrid[x, y])
                    {
                        DrawRectangleOutline(rect, Color.Red * 1);
                    }
                }
            }
        }

        private void DrawRectangleOutline(Rectangle rect, Color color)
        {
            // Top
            RenderContext.SpriteBatch.Draw(RenderContext.Pixel, new Rectangle(rect.Left, rect.Top, rect.Width, 1), color);
            // Bottom
            RenderContext.SpriteBatch.Draw(RenderContext.Pixel, new Rectangle(rect.Left, rect.Bottom - 1, rect.Width, 1), color);
            // Left
            RenderContext.SpriteBatch.Draw(RenderContext.Pixel, new Rectangle(rect.Left, rect.Top, 1, rect.Height), color);
            // Right
            RenderContext.SpriteBatch.Draw(RenderContext.Pixel, new Rectangle(rect.Right - 1, rect.Top, 1, rect.Height), color);
        }

    }
}
