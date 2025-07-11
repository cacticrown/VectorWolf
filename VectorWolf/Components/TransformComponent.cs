using Microsoft.Xna.Framework;

namespace VectorWolf.Components;

public class TransformComponent : Component
{
    public Vector2 PositionOffset;
    public float RotationOffset;

    public Vector2 GlobalPosition => Entity.Position + PositionOffset;
    public float GlobalRotation => Entity.Rotation + RotationOffset;
}
