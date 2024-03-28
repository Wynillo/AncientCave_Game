using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;
using SpritesheetManagement.models;
using SpritesheetManagement.utils;

namespace SpritesheetManagement;

/// <summary>
/// Class for loading sprites from an XML file.
/// </summary>
public static class SpriteLoader
{
    /// <summary>
    /// Loads sprites from a JSON file.
    /// </summary>
    /// <param name="filePath">The path of the JSON file to load sprites from.</param>
    /// <returns>A list of Sprite objects loaded from the JSON file.</returns>
    public static List<Sprite> LoadFromJsonFile(string filePath)
    {
        var sprites = new List<Sprite>();
        
        // Check file existence and read permissions
        if (!Helper.CanAccessFile(filePath)) return sprites;
        
        try
        {
            // Load the JSON data
            var jsonData = File.ReadAllText(filePath);

            var import = JsonSerializer.Deserialize<ImportModel>(jsonData);

            var tw = import.TileWidth;
            var th = import.TileHeight;
            var columns = import.ImageWidth / tw;
            var rows = import.ImageHeight / th;

            for (var y = 0; y < rows; y++)
            {
                for (var x = 0; x < columns; x++)
                {
                    var flattenedSpritesheetIndex = y * columns + x;
                    var currentTile = import.Tiles[flattenedSpritesheetIndex];
                    var sourceRect = new Rectangle(x * tw, y * th, tw, th);
                    sprites.Add(new Sprite(sourceRect,currentTile.Id,currentTile.Type));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while loading from json file: {e.Message}");
        }

        return sprites;
    }
}