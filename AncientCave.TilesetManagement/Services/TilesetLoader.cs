using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using AncientCave.TilesetManagement.Core;

namespace AncientCave.TilesetManagement.Services;

public class TilesetLoader
{
    
    public Tileset LoadTileset(string imagePath, int tileWidth, int tileHeight)
    {
        // Load the image from the path
        Image<Rgba32> image;
        try
        {
            image = Image.Load<Rgba32>(imagePath);
        }
        catch (Exception ex)
        {
            throw new Exception($"Could not load image at path {imagePath}", ex);
        }

        // Create a new tileset
        var tileset = new Tileset(image, tileWidth, tileHeight);

        // Return the loaded tileset
        return tileset;
    }
}