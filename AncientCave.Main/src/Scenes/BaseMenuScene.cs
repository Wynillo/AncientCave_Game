using System.Collections.Generic;
using AncientCave.Main.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AncientCave.Main.Scenes;

public abstract class BaseMenuScene : IScene
{
    protected int _selectedIndex = 0;
    protected List<string> _options;
    protected CustomContentService ContentService;
    
    public virtual void HandleInput()
    {
        if(_options == null || _options.Count == 0)
        {
            return; // Skip the rest of the method if _options is null or empty
        }
        
        SpriteFont font = ContentService.TitleFont; // load your SpriteFont here
        Vector2 position = new Vector2(100, 100); // starting position of the menu
        MouseState mouseState = Mouse.GetState();
        var mousePoint = new Point(mouseState.X, mouseState.Y);
        for (int i = 0; i < _options.Count; i++)
        {
            var size = font.MeasureString(_options[i]);
            var rectangle = new Rectangle(position.ToPoint(), size.ToPoint());
            if (rectangle.Contains(mousePoint))
            {
                _selectedIndex = i;
                break;
            }
            position.Y += font.LineSpacing; // move down for the next line
        }
        
        var keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
        {
            _selectedIndex--;
            if (_selectedIndex < 0)
                _selectedIndex = _options.Count - 1; // Wrap around to the bottom
        }
        else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
        {
            _selectedIndex++;
            if (_selectedIndex >= _options.Count)
                _selectedIndex = 0; // Wrap around to the top
        }
    }

    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);

}