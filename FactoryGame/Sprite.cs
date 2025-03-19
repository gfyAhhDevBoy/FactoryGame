using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FactoryGame
{
    abstract class Sprite
    {
        private Texture2D _texture;
        public Vector2 Position;
        private Vector2 _scale;
        
        public Rectangle Rect { 
            get
            {
                return new Rectangle((int)Position.X - _texture.Width / 2, (int)Position.Y - _texture.Height / 2, _texture.Width, _texture.Height);
            }
        }
    }
}
