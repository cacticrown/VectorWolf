using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using VectorWolf.TileMaps;

namespace VectorWolf.OgmoEditor;

public static class OgmoContext
{
    public static string OgmoVersion;
    public static List<OgmoLayer> OgmoLayers;
    public static List<TileSet> TileSets;

    public static void Initialize(string json)
    {
        JsonDocument document = JsonDocument.Parse(json);

        OgmoVersion = document.RootElement.GetProperty("ogmoVersion").GetString();

        // layers
        JsonElement layersElement = document.RootElement.GetProperty("layers");
        List<OgmoLayer> layers = new List<OgmoLayer>();
        foreach (JsonElement layerElement in layersElement.EnumerateArray())
        {
            OgmoLayer ogmoLayer = new OgmoLayer();

            switch (layerElement.GetProperty("definition").GetString())
            {
                case "tile":
                    ogmoLayer.Definition = Definition.tile;
                    ogmoLayer.GridSize = new Vector2(
                        layerElement.GetProperty("gridSize").GetProperty("x").GetInt32(),
                        layerElement.GetProperty("gridSize").GetProperty("y").GetInt32()
                    );
                    break;
                case "entity":
                    ogmoLayer.Definition = Definition.entity;
                    ogmoLayer.GridSize = new Vector2(
                        layerElement.GetProperty("gridSize").GetProperty("x").GetInt32(),
                        layerElement.GetProperty("gridSize").GetProperty("y").GetInt32()
                    );
                    break;
                default:
                    throw new System.Exception($"Unknown layer definition: {layerElement.GetProperty("definition").GetString()}");
            }

            ogmoLayer.Name = layerElement.GetProperty("name").GetString();


            layers.Add(ogmoLayer);
        }
        OgmoLayers = layers;

        // tilesets
        JsonElement tilesetsElement = document.RootElement.GetProperty("tilesets");
        List<TileSet> tileSets = new List<TileSet>();
        foreach (JsonElement tilesetElement in tilesetsElement.EnumerateArray())
        {
            string name = tilesetElement.GetProperty("label").GetString();
            string texturePath = Path.Combine("Assets", tilesetElement.GetProperty("path").GetString());
            int tileWidth = tilesetElement.GetProperty("tileWidth").GetInt32();
            int tileHeight = tilesetElement.GetProperty("tileHeight").GetInt32();
            int tileSeperationX = tilesetElement.GetProperty("tileSeparationX").GetInt32();
            int tileSeperationY = tilesetElement.GetProperty("tileSeparationY").GetInt32();

            TileSet tileSet = new TileSet(name, texturePath, tileWidth, tileHeight, tileSeperationX, tileSeperationY);
            tileSets.Add(tileSet);
        }
        TileSets = tileSets;
    }
}
