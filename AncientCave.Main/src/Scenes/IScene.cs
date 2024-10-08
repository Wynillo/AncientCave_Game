using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AncientCave.Main.Scenes;

public interface IScene
{
    
    /// <summary>
    /// Handle input relevant to the current state
    /// </summary>
    void HandleInput();

    /// <summary>
    /// Update the state of the game/components
    /// </summary>
    void Update(GameTime gameTime);

    /// <summary>
    /// Draw elements relevant to the current state
    /// </summary>
    void Draw(SpriteBatch spriteBatch);
}