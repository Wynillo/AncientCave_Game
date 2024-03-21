using System;
using System.Collections.Generic;
using AncientCave.States.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AncientCave.States.Implementations;

public abstract class BaseMenuGameState : IGameState
{
    private int _selectedIndex = 0;
    private readonly List<string> _options;

    protected BaseMenuGameState(List<string> options)
    {
        _options = options;
        _selectedIndex = 0;
    }

    public virtual void HandleInput()
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

        _selectedIndex = Math.Clamp(_selectedIndex, 0, _options.Count - 1);
    }

    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);

}