using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using VectorWolf.Collisions;
using VectorWolf.Diagnostics;
using VectorWolf.Graphics;
using VectorWolf.Resources;

namespace VectorWolf.TileMaps;

public class TileMap : Entity
{
    public int[] Tiles;
    public int Width;
    public int Height;
    public int TileWidth;
    public int TileHeight;
    public TileSet TileSet;
    public string TileSetTexturePath;
    public GridCollider GridCollider;

    public TileMap(int width, int height, int tileWidth, int tileHeight, TileSet tileSet, int[] tiles)
    {
        TileSet = tileSet;
        Width = width;
        Height = height;
        TileWidth = tileWidth;
        TileHeight = tileHeight;
        Tiles = tiles;
        GridCollider = new GridCollider(width, height, tileWidth); // GridColliders only support square tiles
    }    
    
    public TileMap(int width, int height, int tileWidth, int tileHeight, TileSet tileSet, int[] tiles, bool isSolid)
    {
        TileSet = tileSet;
        Width = width;
        Height = height;
        TileWidth = tileWidth;
        TileHeight = tileHeight;
        Tiles = tiles;
        GridCollider = new GridCollider(width, height, tileWidth);
        if (isSolid)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i] != -1)
                    GridCollider.Set(i % width, i / width, true);
            }
        }
    }

    public Rectangle GetSourceRectangle(int tile)
    {
        int tilesPerRow = TileSet.Texture.Width / TileWidth;

        int tileX = tile % tilesPerRow;
        int tileY = tile / tilesPerRow;

        return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
    }


    public int GetTile(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return -1;

        return Tiles[y * Width + x];
    }

    public override void Draw()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                int tileIndex = GetTile(x, y);
                if (tileIndex < 0) continue;

                Rectangle sourceRect = GetSourceRectangle(tileIndex);
                Vector2 position = new Vector2(x * TileWidth, y * TileHeight);

                RenderContext.SpriteBatch.Draw(TileSet.Texture, position, sourceRect, Color.White);
            }
        }
    }
}
