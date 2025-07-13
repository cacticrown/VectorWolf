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

AppConfig appConfig = new AppConfig
{
    Title = "VectorWolf Game",
    IsFullScreen = false,
};

Log.Info("This is an example for VectorWolf framework");
Log.Info("Move with WASD and reload the scene by pressing R");
using var game = new App(appConfig, new SampleScene(), new DefaultRenderer());
game.Run();

class SampleScene : Scene
{
    public override void Initialize()
    {
        AddEntity(new SampleEntity());
        AddEntity(new Coin()
        {
            Position = new Vector2(-190, 30)
        });
        Log.Info("Scene was initialized");
    }
}

class SampleEntity : Entity
{
    private Texture2D _pixel;

    public Rectangle Rect = new Rectangle(0, 0, 50, 50);
    public Color Color = Color.Black;

    public RectangleCollider Collider = new RectangleCollider();

    public float Speed = 150f;

    public override void OnSceneStart()
    {
        _pixel = new Texture2D(RenderContext.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        Collider.Size = new Vector2(Rect.Width, Rect.Height);
        Collider.Entity = this;
    }

    public override void Update()
    {
        if(Input.KeyDown(Keys.D))
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

        if (Input.KeyPressed(Keys.R))
        {
            App.Instance.SwitchScene(new SampleScene());
        }

        Rect.X = (int)Position.X;
        Rect.Y = (int)Position.Y;
    }

    public override void Draw()
    {
        RenderContext.SpriteBatch.Draw(_pixel, Rect, Color);
    }
}
class Coin : Entity
{
    private Texture2D _pixel;

    public Rectangle Rect = new Rectangle(0, 0, 35, 35);
    public Color Color = Color.Gold;

    public RectangleCollider Collider = new RectangleCollider();

    public const float Speed = 150f;
    SampleEntity Player;

    public override void OnSceneStart()
    {
        _pixel = new Texture2D(RenderContext.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });
        Player = Scene.GetEntity<SampleEntity>();
    }

    public override void Update()
    {
        Collider.Size = new Vector2(Rect.Width, Rect.Height);
        Collider.Entity = this;

        if (Collider.CollideWith(Player.Collider))
        {
            App.Instance.SwitchScene(new SampleScene());
        }
    }

    public override void Draw()
    {
        Rect.X = (int)Position.X;
        Rect.Y = (int)Position.Y;
        RenderContext.SpriteBatch.Draw(_pixel, Rect, Color);
    }
}