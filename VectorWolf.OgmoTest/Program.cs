using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using VectorWolf;
using VectorWolf.Collisions;
using VectorWolf.Diagnostics;
using VectorWolf.Graphics;
using VectorWolf.Graphics.Renderers;
using VectorWolf.OgmoEditor;
using VectorWolf.Resources;
using VectorWolf.TileMaps;
using VectorWolf.Utils;

EntityRegistry.Register<Entity>("Player");

OgmoContext.Initialize(ResourceManager.LoadText("Assets/TileMaps.ogmo"));
App app = new App(ResourceManager.LoadOgmoScene("Assets/Level2.json"), new DefaultRenderer())
{
    Title = "VectorWolf Ogmo Test",
};


Log.Info($"Ogmo Version: {OgmoContext.OgmoVersion}");
foreach(var layer in OgmoContext.OgmoLayers)
{
    Log.Info($"Layer: {layer.Name}, Definition: {layer.Definition}, Grid Size: {layer.GridSize}");
}
foreach(var tileset in OgmoContext.TileSets)
{
    Log.Info($"Tileset: {tileset.Name}, Texture Path: {tileset.TexturePath}");
}

foreach(var entity in Engine.Instance.Scene.Entities)

    Log.Info($"{entity.Id} {entity.Position}");
var tilemap = Engine.Instance.Scene.GetEntity<TileMap>();
    Log.Info(tilemap.TileSet.ToString());

RenderContext.ActiveCamera.Position = new Vector2(100, 100);
Engine.Instance.Scene.AddEntity(new Player());

app.Run();





class Player : Entity
{
    private Texture2D _pixel;

    public Rectangle Rect = new Rectangle(0, 0, 25, 25);
    public Color Color = Color.Black;

    public RectangleCollider Collider = new RectangleCollider();

    public float Speed = 150f;

    int collisioncount = 0;

    public override void OnSceneStart()
    {
        _pixel = new Texture2D(RenderContext.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        Collider.Size = new Vector2(Rect.Width, Rect.Height);
        Collider.Entity = this;

        RenderContext.ActiveCamera.Zoom = 2;
    }

    public override void Update()
    {
        if (Input.KeyDown(Keys.D))
        {
            Position.X += Speed * Time.DeltaTime;
        }
        if (Input.KeyDown(Keys.A))
        {
            Position.X -= Speed * Time.DeltaTime;
        }
        if (Input.KeyDown(Keys.W))
        {
            Position.Y -= Speed * Time.DeltaTime;
        }
        if (Input.KeyDown(Keys.S))
        {
            Position.Y += Speed * Time.DeltaTime;
        }

        Rect.X = (int)Position.X;
        Rect.Y = (int)Position.Y;

        if (Scene.GetEntity<TileMap>().GridCollider.Collides(Collider.GetRectangle()))
        {
            collisioncount++;
            Log.Debug("player collided with tilemap " + collisioncount);
        }

        RenderContext.ActiveCamera.Position = Position;
    }

    public override void Draw()
    {
        RenderContext.SpriteBatch.Draw(_pixel, Rect, Color);
    }
}