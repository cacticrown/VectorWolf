using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VectorWolf.Graphics.Renderers;

public class DefaultRenderer : Renderer
{
    public override void Render(Scene scene)
    {
        RenderContext.GraphicsDevice.Clear(Color.CornflowerBlue);

        RenderContext.SpriteBatch.Begin(
            sortMode: SpriteSortMode.BackToFront,
            blendState: BlendState.AlphaBlend,
            samplerState: SamplerState.PointClamp,
            depthStencilState: DepthStencilState.None,
            rasterizerState: RasterizerState.CullNone,
            transformMatrix: Camera.GetViewMatrix()
        );

        scene.Draw();

        RenderContext.SpriteBatch.End();
    }
}
