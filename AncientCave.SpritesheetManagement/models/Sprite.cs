using Microsoft.Xna.Framework;

namespace SpritesheetManagement.models;

public class Sprite : SpriteData
{
    public Sprite()
    {
        
    }
    public Sprite(Rectangle sourceRect,int? id, string? type)
    {
        SourceRect = sourceRect;
        Id = id;
        Type = type;
    }
    public new Rectangle SourceRect { get; set; }

}