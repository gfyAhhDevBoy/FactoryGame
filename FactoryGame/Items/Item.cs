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

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            Rectangle dest = new((int)_player.Position.X + (int)offset.X, (int)_player.Position.Y + (int)offset.Y, Rect.Width, Rect.Height);
            spriteBatch.Draw(_texture, dest, Color.White);
        }
    }
}
