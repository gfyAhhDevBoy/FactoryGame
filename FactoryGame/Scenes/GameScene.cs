using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using SurvivalGame;
using System.Diagnostics;

namespace SurvivalGame.Scenes
{
    internal class GameScene : IScene
    {
        private Player _player;
        private Camera _camera;

        List<Sprite> _sprites;
        
        SceneManager _sceneManager;
        GraphicsDevice _graphicsDevice;

        public GameScene(Player player, Camera camera, GraphicsDevice graphicsDevice)
        {
            _player = player;
            _camera = camera;
            _graphicsDevice = graphicsDevice;
        }


        public void Load(ContentManager content)
        {
            _sprites = new();
            _sprites.Add(new Sprite(content.Load<Texture2D>("enemy"), new Vector2(500, 300), Game1.Scale));
            _sprites.Add(new Sprite(content.Load<Texture2D>("enemy"), new Vector2(300, 300), Game1.Scale));
            _sprites.Add(new Sprite(content.Load<Texture2D>("enemy"), new Vector2(100, 100), Game1.Scale));
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch, _camera.Position);
            }
            _player.Draw(spriteBatch, _camera.Position);

            _player.Inventory.Draw(spriteBatch);

            _player.Inventory.GetCurrentSlot().Draw(spriteBatch);
        }


        public void Unload()
        {
        }

        public void Update(GameTime gameTime)
        {
            _camera.Update();
            _camera.Follow(_player.Rect, _player.Origin, new(Game1.ScreenWidth, Game1.ScreenHeight));
            _player.Inventory.Update();
        }
    }
}
