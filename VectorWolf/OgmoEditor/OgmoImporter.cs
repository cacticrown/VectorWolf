using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text.Json;
using VectorWolf.Diagnostics;
using VectorWolf.TileMaps;

namespace VectorWolf.OgmoEditor;

public static class OgmoImporter
{
    public static Scene LoadSceneFromJson(string json)
    {
        Scene scene = new Scene();

        JsonDocument jsonDocument = JsonDocument.Parse(json);

        if (jsonDocument.RootElement.GetProperty("ogmoVersion").GetString() != OgmoContext.OgmoVersion)
            Log.Warning("Loaded Level does not match the ogmo version in omgo context");

        int width = jsonDocument.RootElement.GetProperty("width").GetInt32();
        int height = jsonDocument.RootElement.GetProperty("height").GetInt32();

        foreach (var layer in jsonDocument.RootElement.GetProperty("layers").EnumerateArray())
        {
            int tileWidth = layer.GetProperty("gridCellWidth").GetInt32();
            int tileHeight = layer.GetProperty("gridCellHeight").GetInt32();

            string tileSetName = layer.GetProperty("name").GetString();
            TileSet selectedTileSet = null;
            foreach (TileSet tileset in OgmoContext.TileSets)
            {
                if (tileset.Name == tileSetName)
                {
                    selectedTileSet = tileset;
                }
            }

            TileMap tileMap = new TileMap(width, height, tileWidth, tileHeight, selectedTileSet);
            scene.AddEntity(tileMap);
        }

        return scene;
    }
}
