using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using VectorWolf;
using VectorWolf.Collisions;
using VectorWolf.Diagnostics;
using VectorWolf.Graphics;
using VectorWolf.Graphics.Renderers;
using VectorWolf.Utils;
using VectorWolf.Test;

TestApp app = new TestApp();
Log.Info("This is an example for VectorWolf framework");
Log.Info("Move with WASD and reload the scene by pressing R");
Log.Info("Toggle Debug Collider Rendering by pressing C");
app.Run();