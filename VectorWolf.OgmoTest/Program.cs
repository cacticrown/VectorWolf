using VectorWolf;
using VectorWolf.Diagnostics;
using VectorWolf.Graphics.Renderers;
using VectorWolf.OgmoEditor;
using VectorWolf.Resources;
using VectorWolf.TileMaps;

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

using var game = new App(appConfig, ResourceManager.LoadOgmoScene("Assets/Level2.json"), new DefaultRenderer());
foreach(var entity in game.Scene.Entities)
    Log.Info($"{entity.Id} {entity.Position}");
var tilemap = game.Scene.GetEntity<TileMap>();
    Log.Info(tilemap.TileSet.ToString());
game.Run();