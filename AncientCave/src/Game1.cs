using AncientCave.Services;
using AncientCave.States.Implementations;
using AncientCave.States.Implementations.Title;
using AncientCave.States.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AncientCave;

public class Game1 : Game
{
    private SpriteBatch _spriteBatch;
    private CustomContentManager _customContentManager;

    public Game1()
    {
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // Set game reference in GameStateManager
        GameStateManager.CurrentInstance.Game = this;

        // Initialization logic here
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Initialize custom content manager with game's content manager
        _customContentManager = new CustomContentManager(Content);

        // Load content using custom content manager
        _customContentManager.LoadContent(GraphicsDevice);

        GameStateManager.CurrentInstance.Push(new GameStateTitle(_customContentManager));
    }

    protected override void Update(GameTime gameTime)
    {
        // Process user input for the current game state
        GameStateManager.CurrentInstance.HandleInput();

        // Update the current game state
        GameStateManager.CurrentInstance.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        GameStateManager.CurrentInstance.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public void ExitGame()
    {
        this.Exit();
    }
}