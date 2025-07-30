using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace VectorWolf.ImGuiNet;

public class ImGuiConsole
{
    private struct ColoredLine
    {
        public string Text;
        public Vector4 Color;
    }

    private List<ColoredLine> _lines = new List<ColoredLine>();
    private string _inputBuffer = "";
    private const int InputBufferSize = 256;

    public bool IsVisible { get; set; } = true;

    public void Draw()
    {
        if (!IsVisible)
            return;

        ImGui.Begin("Console");

        if (ImGui.BeginChild("ScrollingRegion", new Vector2(0, -ImGui.GetFrameHeightWithSpacing())))
        {
            foreach (var line in _lines)
            {
                ImGui.PushStyleColor(ImGuiCol.Text, line.Color);
                ImGui.TextWrapped(line.Text);
                ImGui.PopStyleColor();
            }

            if (ImGui.GetScrollY() >= ImGui.GetScrollMaxY())
                ImGui.SetScrollHereY(1.0f);
        }
        ImGui.EndChild();

        if (ImGui.InputText("Input", ref _inputBuffer, InputBufferSize, ImGuiInputTextFlags.EnterReturnsTrue))
        {
            SubmitCommand(_inputBuffer);
            _inputBuffer = "";
        }

        ImGui.End();
    }

    private void SubmitCommand(string command)
    {
        AddLine("> " + command, ConsoleColor.Cyan);

        switch (command.Trim().ToLower())
        {
            case "help":
                AddLine("Available commands: help, clear, echo [message]", ConsoleColor.White);
                break;

            case "clear":
                _lines.Clear();
                break;

            default:
                if (command.StartsWith("echo "))
                {
                    var msg = command.Substring(5);
                    AddLine(msg, ConsoleColor.White);
                }
                else
                {
                    AddLine("Unknown command: " + command, ConsoleColor.Red);
                }
                break;
        }
    }

    public void AddLine(string text, ConsoleColor color = ConsoleColor.White)
    {
        _lines.Add(new ColoredLine { Text = text, Color = ConsoleColorToVector4(color) });
    }

    public Vector4 ConsoleColorToVector4(ConsoleColor color)
    {
        return color switch
        {
            ConsoleColor.Black => new Vector4(0f, 0f, 0f, 1f),
            ConsoleColor.DarkBlue => new Vector4(0f, 0f, 0.5f, 1f),
            ConsoleColor.DarkGreen => new Vector4(0f, 0.5f, 0f, 1f),
            ConsoleColor.DarkCyan => new Vector4(0f, 0.5f, 0.5f, 1f),
            ConsoleColor.DarkRed => new Vector4(0.5f, 0f, 0f, 1f),
            ConsoleColor.DarkMagenta => new Vector4(0.5f, 0f, 0.5f, 1f),
            ConsoleColor.DarkYellow => new Vector4(0.5f, 0.5f, 0f, 1f),
            ConsoleColor.Gray => new Vector4(0.75f, 0.75f, 0.75f, 1f),
            ConsoleColor.DarkGray => new Vector4(0.5f, 0.5f, 0.5f, 1f),
            ConsoleColor.Blue => new Vector4(0f, 0f, 1f, 1f),
            ConsoleColor.Green => new Vector4(0f, 1f, 0f, 1f),
            ConsoleColor.Cyan => new Vector4(0f, 1f, 1f, 1f),
            ConsoleColor.Red => new Vector4(1f, 0f, 0f, 1f),
            ConsoleColor.Magenta => new Vector4(1f, 0f, 1f, 1f),
            ConsoleColor.Yellow => new Vector4(1f, 1f, 0f, 1f),
            ConsoleColor.White => new Vector4(1f, 1f, 1f, 1f),
            _ => new Vector4(1f, 1f, 1f, 1f),
        };
    }
}