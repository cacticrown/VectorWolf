using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using VectorWolf.Graphics.Renderers;

namespace VectorWolf.Graphics;

public static class RenderContext
{
    public static GraphicsDeviceManager Graphics => Engine.Instance._graphics;
    public static GraphicsDevice GraphicsDevice => Engine.Instance.GraphicsDevice;
    public static SpriteBatch SpriteBatch;

    public static List<Renderer> ActiveRenderers = new List<Renderer>();
    public static Camera ActiveCamera = new Camera();

    public static void Draw()
    {
        foreach(Renderer renderer in ActiveRenderers)
        {
            renderer.Render(Engine.Instance.Scene);
        }
    }
}
