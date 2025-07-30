using Microsoft.Xna.Framework;

namespace VectorWolf.Utils;

public static class Time
{
    public static float DeltaTime { get; private set; }
    public static float TotalTime { get; private set; }
    public static GameTime GameTime { get; private set; }

    internal static void Update(GameTime gameTime)
    {
        DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        TotalTime = (float)gameTime.TotalGameTime.TotalSeconds;
        GameTime = gameTime;
    }
}
