using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VectorWolf.Graphics.Renderers;

public class DefaultRenderer : Renderer
{
    public SpriteSortMode SortMode = SpriteSortMode.BackToFront;
    public BlendState BlendState = BlendState.AlphaBlend;
    public SamplerState SamplerState = SamplerState.PointClamp;
    public DepthStencilState DepthStencilState = DepthStencilState.None;
    public RasterizerState RasterizerState = RasterizerState.CullNone;
    public Color BackgroundColor = Color.CornflowerBlue;

    public override void Render(Scene scene)
    {
        RenderContext.GraphicsDevice.Clear(BackgroundColor);

        RenderContext.SpriteBatch.Begin(
            SortMode,
            BlendState,
            SamplerState,
            DepthStencilState,
            RasterizerState,
            transformMatrix: RenderContext.ActiveCamera.GetViewMatrix()
        );

        scene.Draw();

        RenderContext.SpriteBatch.End();
    }
}
