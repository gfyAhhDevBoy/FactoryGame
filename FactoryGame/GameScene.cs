using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryGame
{
    internal class GameScene : IScene
    {
        private Player _player;

        List<Sprite> _sprites;

        public GameScene(Player player)
        {
            _player = player;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
            _player.Draw(spriteBatch);
        }

        public void Load(ContentManager content)
        {
            _sprites = new();
            _sprites.Add(new Sprite(content.Load<Texture2D>("enemy"), new Vector2(500, 300), Game1.Scale));
        }

        public void Unload()
        {
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime, _sprites);
        }
    }
}
