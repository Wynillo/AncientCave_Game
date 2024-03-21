using System;
using System.Collections.Generic;
using AncientCave.Services;
using AncientCave.States.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AncientCave.States.Implementations.Title;

public class GameStateTitle : IGameState
{
    private readonly CustomContentManager _contentManager;
    private List<string> _options;
    private int _selectedIndex;

    public GameStateTitle(CustomContentManager contentManager)
    {
        _contentManager = contentManager;

        _options = new List<string>
        {
            "New Game",
            "Load Game",
            "Options",
            "Exit"
        };

        _selectedIndex = 0; // Default selected option
    }

    public void HandleInput()
    {
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
        
        SpriteFont font = _contentManager.TitleFont; // load your SpriteFont here
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
    }

    public void Update(GameTime gameTime)
    {
        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            // Handle click action
            HandleClickAction();
        }
    }

    private void HandleClickAction()
    {
        switch (_selectedIndex)
        {
            case 0: // New Game
                StartNewGame();
                break;
            case 1: // Load Game
                LoadGame();
                break;
            case 2: // Options
                OpenOptions();
                break;
            case 3: // Exit
                ExitGame();
                break;
            default:
                throw new InvalidOperationException("Invalid menu option selected.");
        }
    }

    private void ExitGame()
    {
        GameStateManager.CurrentInstance.Game.ExitGame();
    }

    private void OpenOptions()
    {
        GameStateManager.CurrentInstance.Push(new GameStateTitleOptions(_contentManager));
    }

    private void LoadGame()
    {
        GameStateManager.CurrentInstance.Push(new GameStateTitleLoadGame());
    }

    private void StartNewGame()
    {
        GameStateManager.CurrentInstance.Push(new GameStateTitleNewGame());
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        var font = _contentManager.TitleFont; // load your SpriteFont here
        var position = new Vector2(100, 100); // starting position of the menu
        for(int i = 0; i < _options.Count; i++)
        {
            var color = (i == _selectedIndex) ? Color.Red : Color.White; // highlight the selected index
            spriteBatch.DrawString(font, _options[i], position, color);
            position.Y += font.LineSpacing; // move down for the next line
        }
    }
}