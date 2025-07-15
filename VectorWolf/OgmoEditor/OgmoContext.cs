using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text.Json;

namespace VectorWolf.OgmoEditor;

public static class OgmoContext
{
    public static string OgmoVersion;
    public static OgmoLayer[] OgmoLayers;

    public static void Initialize(string json)
    {
        JsonDocument document = JsonDocument.Parse(json);

        OgmoContext.OgmoVersion = document.RootElement.GetProperty("ogmoVersion").GetString();

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

        OgmoLayers = layers.ToArray();
    }
}
