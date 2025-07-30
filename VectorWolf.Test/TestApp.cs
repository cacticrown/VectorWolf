using ImGuiNET;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VectorWolf.Diagnostics;
using VectorWolf.Graphics;
using VectorWolf.Graphics.Renderers;
using VectorWolf.ImGuiNet;

namespace VectorWolf.Test;

public class TestApp : App
{
    ImGuiConsole imguiConsole = new();

    public override void Run()
    {
        Title = "VectorWolf Game";
        IsFullScreen = false;
        InitEngine(new SampleScene(), new DefaultRenderer());
        base.Run();
    }

    public override void Initialize()
    {
        ImGuiContext.Initialize();
        Log.ImGuiConsole = imguiConsole;

        Log.Info("This is an example for VectorWolf framework");
        Log.Info("Move with WASD and reload the scene by pressing R");
        Log.Info("Toggle Debug Collider Rendering by pressing C");
    }

    public override void LoadContent()
    {
        ImGuiContext.RebuildFontAtlas();
    }

    public override void Draw()
    {
        ImGuiContext.Begin();

        ImGui.SetNextWindowSize(new System.Numerics.Vector2(360, 180), ImGuiCond.Once);
        ImGui.SetNextWindowPos(new System.Numerics.Vector2(640, 360), ImGuiCond.Once, new System.Numerics.Vector2(0.5f, 0.5f));

        if (ImGui.Begin("Debug Controls", ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse))
        {
            if (ImGui.Button("Reload Scene (R)"))
            {
                Engine.Instance.SwitchScene(new SampleScene());
            }

            if (ImGui.Button("Toggle Colliders (C)"))
            {
                ToggleDebugColliderRendering();
            }

            ImGui.Separator();

            var renderer = RenderContext.ActiveRenderers.OfType<DefaultRenderer>().FirstOrDefault();
            if (renderer != null)
            {
                string status = renderer.DrawDebugColliders ? "ON" : "OFF";
                ImGui.Text($"Collider Rendering: {status}");
            }

            ImGui.End();
        }

        imguiConsole.Draw();

        ImGuiContext.End();
    }



    public override void Update()
    {
        if (Input.KeyPressed(Keys.R))
        {
            Engine.Instance.SwitchScene(new SampleScene());
        }
        if (Input.KeyPressed(Keys.C))
        {
            ToggleDebugColliderRendering();
        }
    }

    public void ToggleDebugColliderRendering()
    {
        RenderContext.ActiveRenderers.OfType<DefaultRenderer>().FirstOrDefault<DefaultRenderer>().DrawDebugColliders = !RenderContext.ActiveRenderers.OfType<DefaultRenderer>().FirstOrDefault<DefaultRenderer>().DrawDebugColliders;
    }
}
