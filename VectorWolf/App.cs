using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using VectorWolf.Graphics;
using VectorWolf.Graphics.Renderers;
using VectorWolf.OgmoEditor;
using VectorWolf.TileMaps;
using VectorWolf.Utils;

namespace VectorWolf;

public class App : Game
{
    public static App Instance;

    public GraphicsDeviceManager _graphics;

    public AppConfig AppConfig;

    public Scene Scene;
    public Scene NextScene;

    public App(AppConfig appConfig, Scene scene, Renderer renderer)
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Scene = scene;
        NextScene = Scene;
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

        _graphics.ApplyChanges();
    }

    public void SwitchScene(Scene scene)
    {
        NextScene = scene;
    }

    public void InitScene(Scene scene)
    {
        scene.Initialize();
        scene.LoadContent();
        scene.FinishedInitializing();
    }

    protected override void Initialize()
    {
        UpdateConfigChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        RenderContext.SpriteBatch = new SpriteBatch(GraphicsDevice);

        foreach(TileSet tileset in OgmoContext.TileSets)
        {
            tileset.LoadContent();
        }

        InitScene(Scene);
    }

    protected override void Update(GameTime gameTime)
    {
        Time.Update(gameTime);
        Input.Update();

        if(Scene != NextScene)
        {
            Scene.OnDestroy();
            Scene = NextScene;
            InitScene(Scene);
        }

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
