using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using VectorWolf.Resources;

namespace VectorWolf.TileMaps;

public class TileMap : Entity
{
    public int[] Tiles;
    public int Width;
    public int Height;
    public int TileWidth;
    public int TileHeight;
    public Texture2D TileSetTexture;
    public string TileSetTexturePath;

    public TileMap(int width, int height, int tileWidth, int tileHeight)
    {
        Width = width;
        Height = height;
        Tiles = new int[width * height];
        TileWidth = tileWidth;
        TileHeight = tileHeight;
    }

    public override void LoadContent()
    {
        TileSetTexture = ResourceManager.LoadTexture(TileSetTexturePath);
    }

    public Rectangle GetSourceRectangle(int tile)
    {
        int tilesPerRow = TileSetTexture.Width / TileWidth;

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
}
