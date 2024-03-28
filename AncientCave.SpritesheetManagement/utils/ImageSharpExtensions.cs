using Microsoft.Xna.Framework.Graphics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SpritesheetManagement.utils;

public static class ImageSharpExtensions
{
    /// <summary>
    /// Converts an ImageSharp image to MonoGame Texture2D
    /// Please note that the original image gets disposed in this method
    /// </summary>
    /// <param name="image">The source imgae</param>
    /// <param name="graphicsDevice">A graphics device</param>
    /// <returns>A Texture2D</returns>
    public static Texture2D ToTexture2D(this Image<Rgba32> image, GraphicsDevice graphicsDevice)
    {
        Texture2D texture;
        
        using (var memoryStream = new MemoryStream())
        {
            image.SaveAsPng(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            texture = Texture2D.FromStream(graphicsDevice, memoryStream);
        }      

        image.Dispose(); // Dispose of the image immediately after creating the texture

        return texture;
    }
}