using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using VectorWolf.Diagnostics;
using VectorWolf.TileMaps;
using static System.Formats.Asn1.AsnWriter;

namespace VectorWolf.OgmoEditor;

public static class OgmoImporter
{
    public static Scene LoadSceneFromJson(string json)
    {
        Scene scene = new Scene();

        JsonDocument jsonDocument = JsonDocument.Parse(json);

        if (jsonDocument.RootElement.GetProperty("ogmoVersion").GetString() != OgmoContext.OgmoVersion)
            Log.Warning("Loaded Level does not match the ogmo version in omgo context");

        List<TileMap> tilemaps = new List<TileMap>();

        foreach (var layer in jsonDocument.RootElement.GetProperty("layers").EnumerateArray())
        {
            string definition = string.Empty;
            foreach (var registeredLayer in OgmoContext.OgmoLayers)
            {
                if(registeredLayer.Name == layer.GetProperty("name").GetString())
                {
                    definition = registeredLayer.Definition.ToString();
                    break;
                }
            }

            switch (definition)
            {
                case "entity":
                    foreach(Entity entity in LoadEntityLayer(layer))
                    {
                        scene.AddEntity(entity);
                    }
                    break;
                case "tile":
                    tilemaps.Add(LoadTileLayer(layer));
                    break;
                default:
                    Log.Error($"Unknown layer definition: {layer.GetProperty("definition").GetString()}");
                    break;
            }
        }

        foreach(TileMap tileMap in tilemaps)
        {
            scene.AddEntity(tileMap);
        }

        return scene;
    }

    public static IEnumerable<Entity> LoadEntityLayer(JsonElement layer)
    {
        List<Entity> entities = new List<Entity>();

        foreach(var Entity in layer.GetProperty("entities").EnumerateArray())
        {
            Entity entity = new Entity();
            entity.Position = new Vector2(
                Entity.GetProperty("x").GetSingle(),
                Entity.GetProperty("y").GetSingle()
            ); 
            entity.Scale = new Vector2(
                Entity.GetProperty("width").GetSingle(),
                Entity.GetProperty("height").GetSingle()
            );
            entity.Rotation = Entity.GetProperty("rotation").GetSingle();
            entity.Id = Entity.GetProperty("id").GetInt32();
            entities.Add(entity);
        }

        return entities;
    }

    public static TileMap LoadTileLayer(JsonElement layer)
    {
        int width = layer.GetProperty("gridCellsX").GetInt32();
        int height = layer.GetProperty("gridCellsY").GetInt32();

        int tileWidth = layer.GetProperty("gridCellWidth").GetInt32();
        int tileHeight = layer.GetProperty("gridCellHeight").GetInt32();

        string tileSetName = layer.GetProperty("tileset").GetString();
        TileSet selectedTileSet = null;
        foreach (TileSet tileset in OgmoContext.TileSets)
        {
            if (tileset.Name == tileSetName)
            {
                selectedTileSet = tileset;
            }
        }

        int[] data = layer.GetProperty("data").EnumerateArray()
            .Select(x => x.GetInt32())
            .ToArray();

        TileMap tileMap = new TileMap(width, height, tileWidth, tileHeight, selectedTileSet, data);
        return tileMap;
    }
}
