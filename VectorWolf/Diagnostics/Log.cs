using System;

namespace VectorWolf.Diagnostics;

public static class Log
{
    public static void Debug(string message) => PrintMessage(message, "DEBUG", ConsoleColor.White);
    public static void Info(string message) => PrintMessage(message, "INFO", ConsoleColor.Gray);
    public static void Warning(string message) => PrintMessage(message, "WARNING", ConsoleColor.Yellow);
    public static void Error(string message) => PrintMessage(message, "ERROR", ConsoleColor.Red);
    public static void Critical(string message) => PrintMessage(message, "CRITICAL", ConsoleColor.DarkRed);

    private static void PrintMessage(string message, string type, ConsoleColor consoleColor)
    {
        Console.ForegroundColor = consoleColor;
        Console.WriteLine($"[{type}] {message}");
        Console.ResetColor();
    }
}
