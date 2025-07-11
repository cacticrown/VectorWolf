using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using VectorWolf.Graphics;
using VectorWolf.Resources;

namespace VectorWolf.Components.Graphics;

public class SpriteComponent : GraphicsComponent
{
    public string TexturePath;
    public Texture2D Texture;

    public override void LoadContent()
    {
        Texture = ResourceManager.LoadTexture(TexturePath);
    }

    public override void Draw()
    {
        RenderContext.SpriteBatch.Draw(
            Texture,
            GlobalPosition,
            null,
            Color,
            Entity.Rotation,
            Origin,
            GlobalScale,
            Effects,
            GlobalLayer
        );
    }
}
