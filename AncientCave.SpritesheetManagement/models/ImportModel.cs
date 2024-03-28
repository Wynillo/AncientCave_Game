namespace SpritesheetManagement.models;

public class ImportModel
{
    public int Columns { get; set; }
    public string Image { get; set; }
    public int ImageHeight { get; set; }
    public int ImageWidth { get; set; }
    public int Margin { get; set; }
    public string Name { get; set; }
    public string ObjectAlignment { get; set; }
    public int Spacing { get; set; }
    public int TileCount { get; set; }
    public string TiledVersion { get; set; }
    public int TileHeight { get; set; }
    public Tile[] Tiles { get; set; }
    public int TileWidth { get; set; }
    public string Type { get; set; }
    public string Version { get; set; }
}

public class Tile
{
    public int Id { get; set; }
    public string Type { get; set; }
}