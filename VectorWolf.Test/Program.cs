using VectorWolf;
using VectorWolf.Graphics.Renderers;

AppConfig appConfig = new AppConfig
{
    Title = "VectorWolf Game",
    Width = 800,
    Height = 600,
    IsFullScreen = false,
    EnableVSync = true,
    AssetsRootDirectory = "Content"
};


using var game = new App(appConfig, new SampleScene(), new DefaultRenderer());
game.Run();



class SampleScene : Scene
{
    public override void Initialize()
    {
        AddEntity(new SampleEntity());


        FinishedInitializing();
    }
}

class SampleEntity : Entity
{
    public override void Update()
    {

    }
}