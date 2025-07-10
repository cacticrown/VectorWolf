using System;
using System.Diagnostics;
using System.Threading;
using VectorWolf;

AppConfig appConfig = new AppConfig
{
    Title = "VectorWolf Game",
    Width = 800,
    Height = 600,
    IsFullScreen = false,
    EnableVSync = true,
    AssetsRootDirectory = "Content"
};


using var game = new App(appConfig, new SampleScene());
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
        Debug.WriteLine($"Entity {Id} is updating.");
    }
}