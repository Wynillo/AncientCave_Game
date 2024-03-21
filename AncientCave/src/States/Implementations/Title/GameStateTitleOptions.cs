using System;
using System.Collections.Generic;
using AncientCave.Services;
using AncientCave.States.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AncientCave.States.Implementations.Title;

public class GameStateTitleOptions : IGameState
{
    private readonly CustomContentManager _contentManager;
    private List<string> _options;
    private int _selectedIndex= 0;

    public GameStateTitleOptions(CustomContentManager contentManager)
    {
        _contentManager = contentManager;

        _options = new List<string>
        {
            "Display-Settings",
            "Audio-Settings",
            "Back to menu"
        };

        _selectedIndex = 0; // Default selected option
    }
    
    public void HandleInput()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            _selectedIndex--;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            _selectedIndex++;
        }

        _selectedIndex = Math.Clamp(_selectedIndex, 0, _options.Count - 1);
    }

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < _options.Count; i++)
        {
            var color = Color.White;
            if (i == _selectedIndex)
            {
                color = Color.Yellow;
            }

            spriteBatch.DrawString(_contentManager.TitleFont, _options[i], new Vector2(50, 50 + i * 20), color);
        }
    }
}