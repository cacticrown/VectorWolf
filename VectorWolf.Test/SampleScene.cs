using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorWolf.Diagnostics;
using VectorWolf.Utils;

namespace VectorWolf.Test;

public class SampleScene : Scene
{
    public override void Initialize()
    {
        AddEntity(new Player());
        AddEntity(new Coin()
        {
            Position = new Vector2(Randomizer.Randomize(-200, 200), Randomizer.Randomize(-150, 150))
        });
        Log.Info("Scene was initialized");
    }
}
