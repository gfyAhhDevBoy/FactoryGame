using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace FactoryGame.UI
{
    class TextButtonElement : IUIElement
    {
        public Vector2 Position;
        private Rectangle _rect;
        public string Text;
        private SpriteFont _font;
        private bool _highlighted;
        private Color _color, _highlightColor;

        public TextButtonElement(Vector2 position, string text, SpriteFont font, Color color, Color highlightColor)
        {
            Position = position;
            _rect = new((int)position.X - (int)font.MeasureString(text).X, (int)position.Y - (int)font.MeasureString(text).Y, (int) font.MeasureString(text).X, (int) font.MeasureString(text).Y);
            _color = color;
            _highlightColor = color;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, Text, new(Position.X - _font.MeasureString(Text).X, Position.Y - _font.MeasureString(Text).X), _highlighted ? _highlightColor : _color);
        }

        public void Update()
        {
            Rectangle mouseRect = new(Mouse.GetState().Position, new Point(1, 1));
            if (mouseRect.Intersects(_rect))
            {
                _highlighted = true;
            } else
            {
                _highlighted = false;
            }
        }
    }
}
