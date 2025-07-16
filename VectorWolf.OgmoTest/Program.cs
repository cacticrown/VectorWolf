using VectorWolf;
using VectorWolf.Diagnostics;
using VectorWolf.Graphics.Renderers;
using VectorWolf.OgmoEditor;
using VectorWolf.Resources;

AppConfig appConfig = new AppConfig
{
    Title = "VectorWolf Ogmo Test",
};

OgmoContext.Initialize(ResourceManager.LoadText("Assets/TileMaps.ogmo"));
Log.Info($"Ogmo Version: {OgmoContext.OgmoVersion}");
foreach(var layer in OgmoContext.OgmoLayers)
{
    Log.Info($"Layer: {layer.Name}, Definition: {layer.Definition}, Grid Size: {layer.GridSize}");
}
foreach(var tileset in OgmoContext.TileSets)
{
    Log.Info($"Tileset: {tileset.Name}, Texture Path: {tileset.TexturePath}");
}

using var game = new App(appConfig, new SampleScene(), new DefaultRenderer());
game.Run();

class SampleScene : Scene
{
    public override void Initialize()
    {
        
    }
}