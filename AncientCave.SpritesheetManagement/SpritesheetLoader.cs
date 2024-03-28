using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SpritesheetManagement.models;
using SpritesheetManagement.utils;

namespace SpritesheetManagement;

public class SpritesheetLoader
{
    public static Spritesheet? LoadSpritesheetWithJson(string spritesheetPath, string jsonPath)
    {
        
        var spritesheet = LoadSpritesheet(spritesheetPath);
        if(spritesheet == null) return null;

        spritesheet.Sprites = SpriteLoader.LoadFromJsonFile(jsonPath);
        
        return spritesheet;
    }

    public static Spritesheet? LoadSpritesheet(string spritesheetPath)
    {
        if (!Helper.CanAccessFile(spritesheetPath)) return null;

        var image = Image.Load<Rgba32>(spritesheetPath);
        var name = Path.GetFileName(spritesheetPath);
        return new Spritesheet()
        {
            StylesheetImage = image,
            Name = name,
            Path = spritesheetPath
        };
    }
    
}