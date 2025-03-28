using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SurvivalGame.UI
{
    class TextButtonElement : IUIElement
    {
        public delegate void ClickEventHandler(object sender, EventArgs e);
        public event ClickEventHandler ClickEvent;

        public Vector2 Position;
        private Rectangle _rect;
        public string Text;
        private SpriteFont _font;
        private bool _highlighted;
        private Color _color, _highlightColor;
        MouseState _prevMouseState;

        public TextButtonElement(Vector2 position, string text, SpriteFont font, Color color, Color highlightColor)
        {
            Position = position;
            Text = text;
            _font = font;
            _rect = new((int)position.X - (int) font.MeasureString(text).X / 2, (int)position.Y - (int)font.MeasureString(text).Y / 2, (int) font.MeasureString(text).X, (int) font.MeasureString(text).Y);
            _color = color;
            _highlightColor = highlightColor;
            _prevMouseState = Mouse.GetState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, Text, new(_rect.X, _rect.Y), _highlighted ? _highlightColor : _color);
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
