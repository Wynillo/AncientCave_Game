using Microsoft.Xna.Framework.Graphics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SpritesheetManagement.utils;

namespace SpritesheetManagement.models;

public class Spritesheet
{
    public string Name { get; set; }
    public string Path { get; set; }
    public Texture2D? Texture { get; set; }
    public Image<Rgba32>? StylesheetImage { get; set; }
    public List<Sprite> Sprites { get; set; } = new();
    
    public void ConvertImageSharpToTexture2D(GraphicsDevice graphicsDevice)
    {
        if (StylesheetImage == null) return;
        Texture = StylesheetImage.ToTexture2D(graphicsDevice);
    }
    
    private bool CheckHasSprites()
    {
        var isSpriteListFilled = Sprites?.Count > 0;
        
        if (isSpriteListFilled) return isSpriteListFilled;
        
        Console.WriteLine("Error: No sprites loaded");
        Console.WriteLine($"Spritesheet Name: {Name}");
        Console.WriteLine($"Spritesheet Path: {Path}");

        return isSpriteListFilled;
    }
    
    public List<Sprite>? GetSpritesByType(string spriteTypeName)
    {
        return !CheckHasSprites() ? null 
            : Sprites!.Where(sprite => sprite.Type == spriteTypeName).ToList();
    }
    
    public Sprite? GetSpriteById(int spriteId)
    {
        if (!CheckHasSprites()) return null;
        var sprite = Sprites.FirstOrDefault(sprite => sprite.Id == spriteId);

        if (sprite != null) return sprite;
        Console.WriteLine($"No sprite found with the Id {spriteId}");
        return null;
    }
}