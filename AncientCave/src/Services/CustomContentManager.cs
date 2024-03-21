using System;
using Microsoft.Xna.Framework;

namespace AncientCave.Services;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class CustomContentManager
{
    private ContentManager _content;

    public CustomContentManager(ContentManager content)
    {
        _content = content;
    }

    /// <summary>
    /// Creates a default texture with a single pixel of the specified color.
    /// </summary>
    /// <param name="graphicsDevice">
    /// The graphics device used to create the texture.
    /// </param>
    /// <returns>
    /// The default texture.
    /// </returns>
    public Texture2D CreateDefaultTexture(GraphicsDevice graphicsDevice)
    {
        Texture2D defaultTexture = new Texture2D(graphicsDevice, 1, 1);
        defaultTexture.SetData(new Color[] { Color.White });
        return defaultTexture;
    }
    
    // List of properties to hold contents(textures, fonts, sounds etc.)

    public Texture2D TitleTexture { get; private set; }    
    public SpriteFont TitleFont { get; private set; }
    
    // ... add more properties as per your content requirements

    public void LoadContent(GraphicsDevice graphicsDevice)
    {
        Texture2D title;
        try
        {        
            TitleTexture = _content.Load<Texture2D>("TitleTexture");
        }
        catch(Exception)
        {
            TitleTexture = CreateDefaultTexture(graphicsDevice);
        }

        TitleFont = _content.Load<SpriteFont>("Default");
        // ... add more content loading as per your requirements
    }
}