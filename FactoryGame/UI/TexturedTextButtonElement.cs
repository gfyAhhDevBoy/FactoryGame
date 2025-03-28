using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SurvivalGame.UI
{
    class TexturedTextButtonElement : IUIElement
    {
        public delegate void ClickEventHandler(object sender, EventArgs e);
        public event ClickEventHandler ClickEvent;

        private Texture2D _texture;
        public Vector2 Position;
        private Rectangle _rect;
        public string Text;
        private SpriteFont _font;
        private bool _highlighted;
        private Color _color, _highlightColor;
        MouseState _prevMouseState;

        public TexturedTextButtonElement(Vector2 position, string text, Texture2D texture, SpriteFont font, Color textColor, Color textHighlightColor)
        {
            Position = position;
            _texture = texture;
            _rect = new((int)position.X - (int)font.MeasureString(text).X, (int)position.Y - (int)font.MeasureString(text).Y, texture.Width, texture.Height);
            _color = textColor;
            _highlightColor = textColor;
            _prevMouseState = Mouse.GetState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rect, _highlighted ? Color.Gray : Color.White);
            spriteBatch.DrawString(_font, Text, new(Position.X - _font.MeasureString(Text).X, Position.Y - _font.MeasureString(Text).X), _highlighted ? _highlightColor : _color);
        }

        public void Update()
        {
            Rectangle mouseRect = new(Mouse.GetState().Position, new Point(1, 1));
            MouseState mouseState = Mouse.GetState();
            if (mouseRect.Intersects(_rect))
            {
                _highlighted = true;
                if(mouseState.LeftButton == ButtonState.Pressed && !(_prevMouseState.LeftButton == ButtonState.Pressed))
                {
                    ClickEvent?.Invoke(this, EventArgs.Empty);
                }
            } else
            {
                _highlighted = false;
            }
        }
    }
}
