using System;
using Myra.Graphics2D.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using AncientCave.Main.Services;

namespace AncientCave.Main.Scenes.Title
{
    public class MainMenuScene : BaseMenuScene
    {
        private readonly VerticalStackPanel _panel;

        public MainMenuScene(CustomContentService contentService)
        {
            ContentService = contentService;

            _panel = new VerticalStackPanel();
            var options = new List<string>
            {
                "New Game",
                "Load Game",
                "Options",
                "Exit"
            };
            
            foreach (var option in options)
            {
                var button = new TextButton { Text = option };
                button.Click += (s, a) => { HandleClickAction(option); };
                _panel.Widgets.Add(button);
            }
        }

        private void HandleClickAction(string option)
        {
            switch (option)
            {
                case "New Game":
                    Game1.Instance.SceneService.Push(new NewGameScene());
                    break;
                case "Load Game":
                    Game1.Instance.SceneService.Push(new LoadGameScene());
                    break;
                case "Options":
                    Game1.Instance.SceneService.Push(new OptionsScene(ContentService));
                    break;
                case "Exit":
                    Game1.Instance.Exit();
                    break;
                default:
                    throw new InvalidOperationException("Invalid menu option selected.");
            }
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Myra takes care of drawing menu items
        }
    }
}