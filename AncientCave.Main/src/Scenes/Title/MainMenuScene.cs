using System;
using System.Collections.Generic;
using AncientCave.Main.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AncientCave.Main.Scenes.Title;
public class MainMenuScene : BaseMenuScene
{
    public MainMenuScene(CustomContentService contentService)
    {
        ContentService = contentService;

        _options = new List<string>
        {
            "New Game",
            "Load Game",
            "Options",
            "Exit"
        };

        _selectedIndex = 0; // Default selected option
    }
    
    private void HandleClickAction()
    {
        switch (_selectedIndex)
        {
            case 0: // New Game
                Game1.Instance.SceneService.Push(new NewGameScene());
                break;
            case 1: // Load Game
                Game1.Instance.SceneService.Push(new LoadGameScene());
                break;
            case 2: // Options
                Game1.Instance.SceneService.Push(new OptionsScene(ContentService));
                break;
            case 3: // Exit
                Game1.Instance.Exit();
                break;
            default:
                throw new InvalidOperationException("Invalid menu option selected.");
        }
    }
    
    public override void Update(GameTime gameTime)
    {
        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            // Handle click action
            HandleClickAction();
        }
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        var font = ContentService.TitleFont; // load your SpriteFont here
        var position = new Vector2(100, 100); // starting position of the menu
        for(int i = 0; i < _options.Count; i++)
        {
            var color = (i == _selectedIndex) ? Color.Red : Color.White; // highlight the selected index
            spriteBatch.DrawString(font, _options[i], position, color);
            position.Y += font.LineSpacing; // move down for the next line
        }
    }
}