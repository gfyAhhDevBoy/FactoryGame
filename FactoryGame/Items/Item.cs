using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FactoryGame.Items
{
    abstract class Item : Sprite
    {
        int _maxDurability;
        public int Durability;

        private Player _player;

        public Item(Texture2D texture, Player player, int scale) : base(texture, player.ItemOrigin, new(scale, scale))
        {
            _player = player;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new((int)(_player.ItemOrigin.X - _texture.Width / 2), (int)(_player.ItemOrigin.Y - _texture.Height / 2), Rect.Width, Rect.Height);
            spriteBatch.Draw(_texture, dest, Color.White);
        }
    }
}
