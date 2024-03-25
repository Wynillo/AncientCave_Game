using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace AncientCave.TilesetManagement.Core;

public class Tileset
{
    private int TileWidth { get; }
    private int TileHeight { get; }
    private Image<Rgba32> Image { get; }
    private List<Tile> Tiles { get; }

    public Tileset(Image<Rgba32> image, int tileWidth, int tileHeight)
    {
        Image = image;
        TileWidth = tileWidth;
        TileHeight = tileHeight;
        Tiles = new List<Tile>();

        InitializeTiles();
    }

    private void InitializeTiles()
    {
        var rows = Image.Height / TileHeight;
        var columns = Image.Width / TileWidth;

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                // Extract the individual tile from the tileset image
                var tileImage =
                    Image.Clone(img => 
                        img.Crop(
                            new Rectangle(j * TileWidth, i * TileHeight, TileWidth, TileHeight)
                            ));

                // Create a new Tile and add it to the Tiles list
                var tile = new Tile(tileImage);
                Tiles.Add(tile);
            }
        }
    }
}