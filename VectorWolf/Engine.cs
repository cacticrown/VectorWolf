using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using VectorWolf.Diagnostics;
using VectorWolf.Graphics;
using VectorWolf.Graphics.Renderers;
using VectorWolf.Utils;

namespace VectorWolf;

public class Engine : Game
{
    public static Engine Instance;

    public GraphicsDeviceManager Graphics;

    public App App;

    public Scene Scene;
    public Scene NextScene;

    public Engine(App app)
    {
        Graphics = new GraphicsDeviceManager(this);
        App = app;
        Instance = this;
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
        RenderContext.Initialize();
        App.Initialize();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        RenderContext.SpriteBatch = new SpriteBatch(GraphicsDevice);

        App.LoadContent();
        foreach(Renderer renderer in RenderContext.Renderers)
        {
            renderer.Initialize();
        }

        if(Scene != null)
            InitScene(Scene);
    }

    protected override void Update(GameTime gameTime)
    {
        Time.Update(gameTime);
        Input.Update();

        if (Scene != NextScene)
        {
            if (Scene != null)
                Scene.OnDestroy();
            App.OnSceneTransition(Scene, NextScene);
            Scene = NextScene;
            GC.Collect(); // collect garbage to make sure the garbage collector won't run during gameplay
            InitScene(Scene);
        }


        App.PreUpdate();

        Scene.Update();

        App.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        if(Scene != null)
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
