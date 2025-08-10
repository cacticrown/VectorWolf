using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VectorWolf.Collisions;

namespace VectorWolf.Graphics.Renderers;

public class DefaultRenderer : Renderer
{
    public SpriteSortMode SortMode = SpriteSortMode.BackToFront;
    public BlendState BlendState = BlendState.AlphaBlend;
    public SamplerState SamplerState = SamplerState.PointClamp;
    public DepthStencilState DepthStencilState = DepthStencilState.None;
    public RasterizerState RasterizerState = RasterizerState.CullNone;
    public Color BackgroundColor = Color.CornflowerBlue;

    public bool DrawDebugColliders = false;
    public int DebugColliderThickness = 2;
    public Color DebugColliderColor = Color.Red;

    public override void Render(Scene scene)
    {
        RenderContext.GraphicsDevice.Clear(BackgroundColor);

        RenderContext.SpriteBatch.Begin(
            SortMode,
            BlendState,
            SamplerState,
            DepthStencilState,
            RasterizerState,
            transformMatrix: RenderContext.Camera.GetViewMatrix()
        );

        scene.Draw();

        if(DrawDebugColliders)
        {
            foreach (var entity in App.Instance.Scene.Entities)
            {
                if (entity.GetComponent<RectangleCollider>() != null)
                {
                    var collider = entity.GetComponent<RectangleCollider>() as RectangleCollider;
                    collider.DebugDraw(DebugColliderThickness, DebugColliderColor);
                }
            }
        }

        RenderContext.SpriteBatch.End();
    }
}
