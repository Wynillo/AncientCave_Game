using System.Collections.Generic;
using AncientCave.Main.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AncientCave.Main.Services
{
    public class SceneService
    {
        private readonly Stack<IScene> _gameStates = new();

        public void HandleInput()
        {
            if (_gameStates.Count > 0)
                _gameStates.Peek().HandleInput();
        }
        
        public void Update(GameTime gameTime)
        {
            if (_gameStates.Count > 0)
                _gameStates.Peek().Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_gameStates.Count > 0)
                _gameStates.Peek().Draw(spriteBatch);
        }

        public void Push(IScene newState)
        {
            _gameStates.Push(newState);
        }

        public void Pop()
        {
            if (_gameStates.Count > 0)
                _gameStates.Pop();
        }

        public IScene GetCurrentState()
        {
            return _gameStates.Count > 0 ? _gameStates.Peek() : null;
        }
    }
}