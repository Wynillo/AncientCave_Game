using System.Drawing;
using SixLabors.ImageSharp;

namespace AncientCave.TilesetManagement.Core;

public class Tile
{
    public Image Image { get; set; } // Bitmap representation of the tile

    public TyleType Type { get; set; }
    // You can add more properties if necessary. 

    public Tile(Image image)
    {
        Image = image;
    }
}

public enum TyleType
{
    Wall,
    Path
}