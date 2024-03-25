using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace SpritesheetManagement;

public class Spritesheet
{
    public Texture2D Texture { get; private set; }
    private Dictionary<string, Sprite> Sprites { get; set; }

    public Spritesheet(string texturePath, string dataPath = null)
    {
        Load(texturePath, dataPath);
    }

    private void Load(string texturePath, string dataPath)
    {
        // Load the Texture2D from `texturePath` here using your specific method

        Sprites = new Dictionary<string, Sprite>();

        if (dataPath != null)
        {
            // Parse an XML or other data file at `dataPath`
            // Fill the `Sprites` dictionary with `Sprite` instances
        }
        else
        {
            // Define the sprites on your own
            // For demonstration, we'll create a single sprite that spans the entire sheet
            // In reality, you'd probably have a more complex arrangement here
            Sprite sprite = new Sprite
            {
                Name = "fullSheet",
                SourceRect = new Rectangle(0, 0, Texture.Width, Texture.Height)
            };
            Sprites.Add(sprite.Name, sprite);
        }
    }

    public Sprite GetSprite(string spriteName)
    {
        if (Sprites.ContainsKey(spriteName))
        {
            return Sprites[spriteName];
        }

        return null; // Handle missing sprite here - return a default sprite, log an error, or throw an exception
    }
}