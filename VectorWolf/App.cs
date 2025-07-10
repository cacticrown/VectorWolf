using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using VectorWolf.Graphics.Renderers;

namespace VectorWolf;

public class App : Game
{
    public static App Instance;

    public GraphicsDeviceManager _graphics;
    public SpriteBatch _spriteBatch;

    public AppConfig AppConfig;
    public string AssetsRootDirectory => AppConfig.AssetsRootDirectory;
    public Scene Scene;

    public App(AppConfig appConfig, Scene scene, Renderer renderer)
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Scene = scene;
        AppConfig = appConfig;
        Instance = this;
    }

    public void UpdateConfigChanges()
    {
        Window.Title = AppConfig.Title;
        _graphics.PreferredBackBufferWidth = AppConfig.Width;
        _graphics.PreferredBackBufferHeight = AppConfig.Height;
        _graphics.IsFullScreen = AppConfig.IsFullScreen;
        _graphics.SynchronizeWithVerticalRetrace = AppConfig.EnableVSync;
        
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Scene.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Scene.Update();

#if DEBUG 
        Window.Title = $"{AppConfig.Title} - FPS: {1 / gameTime.ElapsedGameTime.TotalSeconds:F2}";
#endif

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        

        base.Draw(gameTime);
    }
}
