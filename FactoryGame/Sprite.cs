using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FactoryGame
{
    class Sprite
    {
        protected Texture2D _texture;
        public Vector2 Position;
        protected Vector2 _scale;
        
        public Rectangle Rect { 
            get
            {
                return new Rectangle((int)Position.X - _texture.Width / 2, (int)Position.Y - _texture.Height / 2, _texture.Width * (int) _scale.X, _texture.Height*(int)_scale.Y);
            }
        }

        public Sprite(Texture2D texture, Vector2 position, Vector2 scale)
        {
            _texture = texture;
            Position = position;
            _scale = scale;
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            Rectangle dest = new(
                Rect.X + (int)offset.X,
                Rect.Y + (int)offset.Y,
                Rect.Width,
                Rect.Height
            );
            spriteBatch.Draw(_texture, dest, Color.White);
        }
    }
}
