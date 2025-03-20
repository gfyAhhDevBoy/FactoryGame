using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryGame.Scenes
{
    internal class GameScene : IScene
    {
        private Player _player;
        private Camera _camera;

        List<Sprite> _sprites;

        SceneManager _sceneManager;

        public GameScene(Player player, Camera camera)
        {
            _player = player;
            _camera = camera;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch, _camera.Position);
            }
            _player.Draw(spriteBatch, _camera.Position);
        }

        public void Load(ContentManager content)
        {
            _sprites = new();
            _sprites.Add(new Sprite(content.Load<Texture2D>("enemy"), new Vector2(500, 300), Game1.Scale));
            _sprites.Add(new Sprite(content.Load<Texture2D>("enemy"), new Vector2(300, 300), Game1.Scale));
            _sprites.Add(new Sprite(content.Load<Texture2D>("enemy"), new Vector2(100, 100), Game1.Scale));
        }

        public void Unload()
        {
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime, _sprites);
            _camera.Follow(_player.Rect, new(Game1.ScreenWidth, Game1.ScreenHeight));
        }
    }
}
