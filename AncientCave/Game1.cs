﻿using System.IO;
using AncientCave.Scenes.Title;
using AncientCave.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Extensions.Configuration;

namespace AncientCave;

public class Game1 : Game
{
    private SpriteBatch _spriteBatch;
    private CustomContentService _customContentService;
    private readonly GraphicsDeviceManager _graphics;
    public SceneService SceneService { get; }

    private static Game1 _instance;
    public GameSettings GameSettings { get; private set; }
    public static Game1 Instance
    {
        get { return _instance ??= new Game1(); }
    }
    
    private Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        SceneService = new SceneService();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // From Microsoft.Extensions.Configuration.FileExtensions
            .AddJsonFile("appsettings.json", optional: true,
                reloadOnChange: true); // From Microsoft.Extensions.Configuration.Json

        var config = configBuilder.Build();
        GameSettings = new GameSettings();
        config.GetSection("Display").Bind(GameSettings.Display);
        config.GetSection("Audio").Bind(GameSettings.Audio);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Initialize custom content manager with game's content manager
        _customContentService = new CustomContentService(Content);

        // Load content using custom content manager
        _customContentService.LoadContent(GraphicsDevice);

        SceneService.Push(new MainMenuScene(_customContentService)); // updated SceneManager.CurrentInstance to SceneManager
    }

    protected override void Update(GameTime gameTime)
    {
        // Process user input for the current game state
        SceneService.HandleInput(); 
        SceneService.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        SceneService.Draw(_spriteBatch); 
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}