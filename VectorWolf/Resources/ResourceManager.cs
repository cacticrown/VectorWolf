using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using VectorWolf.Graphics;

namespace VectorWolf.Resources;

public static class ResourceManager
{
    public static Dictionary<string, Texture2D> Textures { get; } = new Dictionary<string, Texture2D>();

    public static Texture2D LoadTexture(string path)
    {
        if(Textures.TryGetValue(path, out var texture))
            return texture;

        Stream stream = File.OpenRead(path);
        texture = Texture2D.FromStream(RenderContext.GraphicsDevice, stream);

        Textures.Add(path, texture);
        return texture;
    }
}
