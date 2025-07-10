using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VectorWolf.Components.Graphics;

public abstract class GraphicsComponent : Component
{
    public Vector2 Position = Vector2.Zero;
    public Vector2 Origin = Vector2.Zero;
    public Vector2 Scale = Vector2.One;
    public float Rotation = 0f;
    public Color Color = Color.White;
    public SpriteEffects Effects = SpriteEffects.None;
}
