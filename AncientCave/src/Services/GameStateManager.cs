using System;
using System.Collections.Generic;
using AncientCave.States.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AncientCave.Services
{
    public class GameStateManager
    {
        private readonly Stack<IGameState> _gameStates;
        public Game1 Game { get; set; }

        private static readonly Lazy<GameStateManager> Lazy =
            new Lazy<GameStateManager>(() => new GameStateManager());

        public static GameStateManager CurrentInstance => Lazy.Value;

        private GameStateManager()
        {
            _gameStates = new Stack<IGameState>();
        }

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

        public void Push(IGameState newState)
        {
            _gameStates.Push(newState);
        }

        public void Pop()
        {
            if (_gameStates.Count > 0)
                _gameStates.Pop();
        }

        public IGameState GetCurrentState()
        {
            if (_gameStates.Count > 0)
                return _gameStates.Peek();

            return null;
        }
    }
}