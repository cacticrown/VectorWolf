using System;

namespace VectorWolf.Utils;

public static class Randomizer
{
    private static Random random = new Random(DateTime.Now.Second);

    public static int Randomize(int min, int max) => random.Next(min, max);
}
