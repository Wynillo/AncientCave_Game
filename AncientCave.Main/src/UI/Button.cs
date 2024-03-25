using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AncientCave.Main.UI;

public class Button
{
    #region Fields

    private MouseState _currentMouse;

    private readonly SpriteFont _font;

    private bool _isHovering;

    private MouseState _previousMouse;

    private readonly Texture2D _texture;

    #endregion

    #region Properties

    public EventHandler Click { get; set; }

    public bool Clicked { get; private set; }

    public float Layer { get; set; }

    public Vector2 Origin => new(_texture.Width / 2, _texture.Height / 2);

    public Color PenColour { get; set; }

    public Vector2 Position { get; set; }

    private Rectangle Rectangle => new(
        (int)Position.X - ((int)Origin.X),
        (int)Position.Y - (int)Origin.Y,
        _texture.Width, _texture.Height);

    public string Text1 { get; set; }

    #endregion

    #region Methods

    public Button(Texture2D texture, SpriteFont font)
    {
        _texture = texture;

        _font = font;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        var color = Color.White;

        if (_isHovering)
            color = Color.Gray;

        spriteBatch.Draw(_texture, Position, null, color, 0f, Origin, 1f, SpriteEffects.None, Layer);

        if (string.IsNullOrEmpty(Text1)) return;
        var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text1).X / 2);
        var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text1).Y / 2);

        spriteBatch.DrawString(_font, Text1, new Vector2(x, y), PenColour, 0f, new Vector2(0, 0), 1f,
            SpriteEffects.None,
            Layer + 0.01f);
    }

    public void Update(GameTime gameTime)
    {
        _previousMouse = _currentMouse;
        _currentMouse = Mouse.GetState();

        var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

        _isHovering = false;

        if (!mouseRectangle.Intersects(Rectangle)) return;

        _isHovering = true;

        if (_currentMouse.LeftButton == ButtonState.Released
            && _previousMouse.LeftButton == ButtonState.Pressed)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }

    #endregion
}