using VectorWolf.Graphics.Renderers;
using VectorWolf.OgmoEditor;

namespace VectorWolf;

public class App
{
    public static App Instance;

    public Engine Engine;
    public string Title { get; set; } = "VectorWolf Game";
    public int Width { get; set; } = 800;
    public int Height { get; set; } = 480;
    public bool IsFullScreen { get; set; } = false;

    public App(Scene scene, Renderer renderer)
    {
        Engine = new Engine(this, scene, renderer);
        Instance = this;
    }

    public Scene Scene => Engine.Scene;
    public void SwitchScene(Scene scene) => Engine.SwitchScene(scene);

    public void Run() => Engine.Run();
    public void ApplyChanges() => Engine.UpdateConfigChanges();

    public virtual void Initialize() { }
    public virtual void LoadContent() { }
    public virtual void Update() { }
    public virtual void Draw() { }
    public virtual void OnExit() { }
    public virtual void OnSceneTransition(Scene from, Scene to) { }
}
