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

public class Engine : Game
{
    public static Engine Instance;

    public GraphicsDeviceManager _graphics;

    public App App;

    public Scene Scene;
    public Scene NextScene;

    public Engine(App app, Scene scene, Renderer renderer)
    {
        _graphics = new GraphicsDeviceManager(this);
        IsMouseVisible = true;
        Scene = scene;
        NextScene = Scene;
        App = app;
        Instance = this;
        RenderContext.ActiveRenderers.Add(renderer);
    }

    public void UpdateConfigChanges()
    {
        Window.Title = App.Title;
        _graphics.PreferredBackBufferWidth = App.Width;
        _graphics.PreferredBackBufferHeight = App.Height;
        _graphics.IsFullScreen = App.IsFullScreen;

        _graphics.ApplyChanges();
    }

    public void SwitchScene(Scene scene)
    {
        NextScene = scene;
        App.OnSceneTransition(Scene, NextScene);
    }

    public void InitScene(Scene scene)
    {
        scene.Initialize();
        scene.LoadContent();
        scene.FinishedInitializing();
    }

    protected override void Initialize()
    {
        App.Initialize();
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

        App.LoadContent();
        foreach(Renderer renderer in RenderContext.ActiveRenderers)
        {
            renderer.Initialize();
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
        App.Update();

#if DEBUG 
        Window.Title = $"{App.Title} - FPS: {1 / gameTime.ElapsedGameTime.TotalSeconds:F2}";
#endif

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        RenderContext.Draw();

        App.Draw();

        base.Draw(gameTime);
    }

    protected override void OnExiting(object sender, ExitingEventArgs args)
    {
        App.OnExit();
        base.OnExiting(sender, args);
    }
}
