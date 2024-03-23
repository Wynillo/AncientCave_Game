using System.Collections.Generic;
using AncientCave.ECS.Entities;
using AncientCave.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AncientCave.Scenes.Title;

public class OptionsScene : BaseMenuScene
{
    // Assuming that GameSettings is in scope and Game1 has a property to access it
    private GameSettings _gameSettings = Game1.Instance.GameSettings;

    public OptionsScene(CustomContentService contentService)
    {
        ContentService = contentService;

        // Assuming that GameSettings has a method GetOptions() that returns a list of strings
        _options = new List<string>();

        _selectedIndex = 0; // Default selected option
    }

    public override void Update(GameTime gameTime)
    {
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