using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using VectorWolf.Graphics;
using VectorWolf.OgmoEditor;
using VectorWolf.TileMaps;

namespace VectorWolf.Resources;

public static class ResourceManager
{
    public static string ContentRoot = "Content";

    public static Dictionary<string, Texture2D> Textures { get; } = new Dictionary<string, Texture2D>();

    public static Texture2D LoadTexture(string path)
    {
        if(Textures.TryGetValue(Path.Combine(ContentRoot, path), out var texture))
            return texture;

        Stream stream = File.OpenRead(path);
        texture = Texture2D.FromStream(RenderContext.GraphicsDevice, stream);

        Textures.Add(path, texture);
        return texture;
    }

    public static string LoadText(string path)
    {
        return File.ReadAllText(Path.Combine(ContentRoot, path));
    }

    public static Scene LoadOgmoScene(string path)
    {
        string json = File.ReadAllText(Path.Combine(ContentRoot, path));
        return OgmoImporter.LoadSceneFromJson(json);
    }
}
