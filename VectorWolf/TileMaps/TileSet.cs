using Microsoft.Xna.Framework.Graphics;
using VectorWolf.Resources;

namespace VectorWolf.TileMaps;

public class TileSet
{
    public Texture2D Texture;
    public string TexturePath;

    public int TileWidth;
    public int TileHeight;
    public int TileSeperationX;
    public int TileSeperationY;

    public string Name;

    public TileSet(string name, string texturePath, int tileWidth, int tileHeight, int tileSeperationX = 0, int tileSeperationY = 0)
    {
        Name = name;
        TexturePath = texturePath;
        TileWidth = tileWidth;
        TileHeight = tileHeight;
        TileSeperationX = tileSeperationX;
        TileSeperationY = tileSeperationY;
    }

    public void LoadContent()
    {
        Texture = ResourceManager.LoadTexture(TexturePath);
    }
}
