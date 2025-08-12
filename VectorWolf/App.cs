using VectorWolf.Graphics.Renderers;

namespace VectorWolf;

public class App
{
    public static App Instance;

    public Engine Engine;

    public App()
    {
        Instance = this;
        Engine = new Engine(this);
    }

    public Scene Scene => Engine.Scene;
    public void SwitchScene(Scene scene) => Engine.SwitchScene(scene);

    public void Run() => Engine.Run();

    public virtual void Initialize() { }
    public virtual void LoadContent() { }
    public virtual void PreUpdate() { }
    public virtual void Update() { }
    public virtual void Draw() { }
    public virtual void OnExit() { }
    public virtual void OnSceneTransition(Scene from, Scene to) { }
}
