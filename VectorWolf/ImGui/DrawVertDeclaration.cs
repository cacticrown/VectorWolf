
// Based on code by Mezo (2023), licensed under the MIT License.
// See LICENSE or visit https://github.com/tsMezotic/MonoGame.ImGuiNet for more details.

using Microsoft.Xna.Framework.Graphics;
using ImGuiNET;

namespace VectorWolf.ImGuiNet;

public static class DrawVertDeclaration
{
    public static readonly VertexDeclaration Declaration;

    public static readonly int Size;

    static DrawVertDeclaration()
    {
        unsafe { Size = sizeof(ImDrawVert); }

        Declaration = new VertexDeclaration(
            Size,

            // Position
            new VertexElement(0, VertexElementFormat.Vector2, VertexElementUsage.Position, 0),

            // UV
            new VertexElement(8, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),

            // Color
            new VertexElement(16, VertexElementFormat.Color, VertexElementUsage.Color, 0)
        );
    }
}