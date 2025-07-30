using Microsoft.Xna.Framework;
using VectorWolf.ImGuiNet;
using VectorWolf.Utils;

namespace VectorWolf.ImGuiNet;

public static class ImGuiContext
{
    private static ImGuiRenderer _renderer;

    public static void Initialize()
    {
        _renderer = new ImGuiRenderer(Engine.Instance);
    }

    public static void Begin()
    {
        _renderer.BeginLayout(Time.GameTime);
    }

    public static void End()
    {
        _renderer.EndLayout();
    }

    public static void RebuildFontAtlas() => _renderer?.RebuildFontAtlas();
}
