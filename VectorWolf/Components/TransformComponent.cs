using Microsoft.Xna.Framework;

namespace VectorWolf.Components;

public class TransformComponent : Component
{
    public Vector2 PositionOffset;
    public Vector2 ScaleOffset;
    public float RotationOffset;

    public Vector2 GlobalPosition => Entity.Position + PositionOffset;
    public Vector2 GlobalScale => Entity.Scale + ScaleOffset;
    public float GlobalRotation => Entity.Rotation + RotationOffset;
}
