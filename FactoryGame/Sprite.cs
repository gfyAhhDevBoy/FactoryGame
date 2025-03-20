using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FactoryGame
{
    class Sprite
    {
        private Texture2D _texture;
        public Vector2 Position;
        private Vector2 _scale;
        
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

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Rect, Color.White);
        }
    }
}
