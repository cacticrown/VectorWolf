using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using VectorWolf.Graphics;
using VectorWolf.Graphics.Renderers;
using VectorWolf.Utils;

namespace VectorWolf;

public class App : Game
{
    public static App Instance;

    public GraphicsDeviceManager _graphics;

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
        RenderContext.ActiveRenderers.Add(renderer);
    }

    public void UpdateConfigChanges()
    {
        Window.Title = AppConfig.Title;
        _graphics.PreferredBackBufferWidth = AppConfig.Width;
        _graphics.PreferredBackBufferHeight = AppConfig.Height;
        _graphics.IsFullScreen = AppConfig.IsFullScreen;

        _graphics.SynchronizeWithVerticalRetrace = AppConfig.EnableVSync;
        IsFixedTimeStep = AppConfig.EnableVSync;

        _graphics.ApplyChanges();
    }

    public void SwitchScene(Scene scene)
    {
        Scene.OnDestroy();
        Scene = scene;
        InitScene();
    }

    public void InitScene()
    {
        Scene.Initialize();
        Scene.FinishedInitializing();
    }

    protected override void Initialize()
    {
        UpdateConfigChanges();

        InitScene();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        RenderContext.SpriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        Time.Update(gameTime);
        Input.Update();

        Scene.Update();

#if DEBUG 
        Window.Title = $"{AppConfig.Title} - FPS: {1 / gameTime.ElapsedGameTime.TotalSeconds:F2}";
#endif

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {

        RenderContext.Draw();
        

        base.Draw(gameTime);
    }
}
