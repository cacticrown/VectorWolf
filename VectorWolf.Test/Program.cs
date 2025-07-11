using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VectorWolf;
using VectorWolf.Graphics;
using VectorWolf.Graphics.Renderers;
using VectorWolf.Utils;

AppConfig appConfig = new AppConfig
{
    Title = "VectorWolf Game",
    IsFullScreen = false,
    EnableVSync = true,
    AssetsRootDirectory = "Assets"
};

using var game = new App(appConfig, new SampleScene(), new DefaultRenderer());
game.Run();

class SampleScene : Scene
{
    public override void Initialize()
    {
        AddEntity(new SampleEntity());
        base.Initialize();
    }
}

class SampleEntity : Entity
{
    private Texture2D _pixel;

    public Rectangle Rect = new Rectangle(10, 10, 100, 100);
    public Color Color = Color.Black;

    public const float Speed = 150f;

    public override void OnSceneStart()
    {
        _pixel = new Texture2D(RenderContext.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });
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

        Rect.X = (int)Position.X;
        Rect.Y = (int)Position.Y;
    }

    public override void Draw()
    {
        RenderContext.SpriteBatch.Draw(_pixel, Rect, Color);
    }
}
