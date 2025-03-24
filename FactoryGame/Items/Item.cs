using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace FactoryGame.Items
{
    abstract class Item : Sprite
    {
        int _maxDurability;
        public int Durability;
        public string Name;

        private Player _player;

        public Item(Texture2D texture, Player player, string name, int scale) : base(texture, player.ItemOrigin, new(scale, scale))
        {
            _player = player;
            Name = name;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            Rectangle dest = new((int)_player.Position.X + (int)offset.X, (int)_player.Position.Y + (int)offset.Y, Rect.Width, Rect.Height);
            spriteBatch.Draw(_texture, dest, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = new((int)_player.ItemOrigin.X, (int)_player.ItemOrigin.Y, Rect.Width, Rect.Height);
            SpriteEffects rot = SpriteEffects.None;
            if(_player.Rotation == SpriteEffects.None) 
                rot = SpriteEffects.FlipHorizontally;
            if (_player.Rotation == SpriteEffects.FlipHorizontally)
                rot = SpriteEffects.None;
            spriteBatch.Draw(_texture, dest, null, Color.White, 0f, new(), rot, 0f);
        }

        public override string ToString()
        
            => string.Format("Name: {0}, Texture: {1}", Name, _texture.ToString());
        

        public virtual void Interact()
        {
            Debug.WriteLine(Name + " clicked!");
        }
    }
}
