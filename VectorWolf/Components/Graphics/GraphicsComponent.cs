using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VectorWolf.Components.Graphics;

public abstract class GraphicsComponent : TransformComponent
{
    public Vector2 Origin = Vector2.Zero;
    public Color Color = Color.White;
    public SpriteEffects Effects = SpriteEffects.None;
}
