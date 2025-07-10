using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VectorWolf.Graphics;

public static class RenderContext
{
    public static GraphicsDeviceManager Graphics => App.Instance._graphics;
    public static GraphicsDevice GraphicsDevice => App.Instance.GraphicsDevice;
    public static SpriteBatch SpriteBatch => App.Instance._spriteBatch;
}
