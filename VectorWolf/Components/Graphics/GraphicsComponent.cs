using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VectorWolf.Components.Graphics;

public abstract class GraphicsComponent : TransformComponent, IDraw
{
    public Vector2 Origin = Vector2.Zero;
    public Color Color = Color.White;
    public SpriteEffects Effects = SpriteEffects.None;
    public float LayerOffset = 0;
    public float GlobalLayer => Entity.Layer + LayerOffset;

    public virtual void Draw()
    {

    }
}
