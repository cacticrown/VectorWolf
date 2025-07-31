using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using VectorWolf.Graphics.Renderers;

namespace VectorWolf.Graphics;

public static class RenderContext
{
    public static GraphicsDeviceManager Graphics => Engine.Instance.Graphics;
    public static GraphicsDevice GraphicsDevice => Engine.Instance.GraphicsDevice;
    public static SpriteBatch SpriteBatch;

    public static List<Renderer> Renderers = new List<Renderer>();
    public static T GetRenderer<T>() where T : Renderer
    {
        foreach (Renderer renderer in Renderers)
        {
            if (renderer is T typedRenderer)
                return typedRenderer;
        }
        return null;
    }

    public static Camera Camera = new Camera();

    // used for debug rendering
    public static Texture2D Pixel;

    public static void Initialize()
    {
        Pixel = new Texture2D(GraphicsDevice, 1, 1);
        Pixel.SetData(new[] { Color.White });
    }

    public static void Draw()
    {
        foreach(Renderer renderer in Renderers)
        {
            renderer.Render(Engine.Instance.Scene);
        }
    }
}
