using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FactoryGame.Items
{
    abstract class Item : Sprite
    {
        int _maxDurability;
        public int Durability;

        private Texture2D _texture;
        private int _scale;

        public Rectangle Rect
        {
            get
            {
                return new(0, 0, _texture.Width * (int)_scale, _texture.Height * (int)_scale);
            }
        }

        public Item(Texture2D texture, int scale)
        {
            _texture = texture;
            _scale = scale;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Player player)
        {
            Rectangle dest = new((int)(player.ItemOrigin.X - _texture.Width / 2), (int)(player.ItemOrigin.Y - _texture.Height / 2), Rect.Width, Rect.Height);
            spriteBatch.Draw(_texture, dest, Color.White);
        }
    }
}
