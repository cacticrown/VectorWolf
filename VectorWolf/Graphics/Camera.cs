using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VectorWolf;

public class Camera : Component
{
    public Vector2 Position = Vector2.Zero;
    public float Rotation = 0f;
    public float Zoom = 1f;
    public bool FollowEntity = false;

    public int ViewportWidth => Engine.Instance.GraphicsDevice.Viewport.Width;
    public int ViewportHeight => Engine.Instance.GraphicsDevice.Viewport.Height;

    public Matrix GetViewMatrix()
    {
        if(FollowEntity)
            return
                Matrix.CreateTranslation(new Vector3(-Entity.Position, 0f)) *
                Matrix.CreateRotationZ(Entity.Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1f) *
                Matrix.CreateTranslation(new Vector3(ViewportWidth / 2f, ViewportHeight / 2f, 0f));
        else
            return
                Matrix.CreateTranslation(new Vector3(-Position, 0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1f) *
                Matrix.CreateTranslation(new Vector3(ViewportWidth / 2f, ViewportHeight / 2f, 0f));
    }

    public Vector2 WorldToScreen(Vector2 worldPos)
    {
        return Vector2.Transform(worldPos, GetViewMatrix());
    }

    public Vector2 ScreenToWorld(Vector2 screenPos)
    {
        Matrix inverse = Matrix.Invert(GetViewMatrix());
        return Vector2.Transform(screenPos, inverse);
    }
}
