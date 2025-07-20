using Microsoft.Xna.Framework;

namespace VectorWolf.OgmoEditor;

public struct OgmoLayer
{
    public Definition Definition;
    public string Name;
    public Vector2 GridSize;
}

public enum Definition
{
    tile,
    entity,
}