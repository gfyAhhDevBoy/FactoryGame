using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using FactoryGame.UI;
using System.Diagnostics;

namespace FactoryGame.Scenes
{
    internal class GameScene : IScene
    {
        private Player _player;
        private Camera _camera;

        List<Sprite> _sprites;

        SceneManager _sceneManager;
        GraphicsDevice _graphicsDevice;

        UIManager _inventoryUI;

        public GameScene(Player player, Camera camera, GraphicsDevice graphicsDevice)
        {
            _player = player;
            _camera = camera;
            _graphicsDevice = graphicsDevice;
            _inventoryUI = new();
        }


        public void Load(ContentManager content)
        {
            _sprites = new();
            _sprites.Add(new Sprite(content.Load<Texture2D>("enemy"), new Vector2(500, 300), Game1.Scale));
            _sprites.Add(new Sprite(content.Load<Texture2D>("enemy"), new Vector2(300, 300), Game1.Scale));
            _sprites.Add(new Sprite(content.Load<Texture2D>("enemy"), new Vector2(100, 100), Game1.Scale));

            _inventoryUI.Add(new UIRectangle(Game1.ScreenWidth / 2 - 412, Game1.ScreenHeight - 100, 825, 100, Color.DarkGray, _graphicsDevice));
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch, _camera.Position);
            }
            _player.Draw(spriteBatch, _camera.Position);

            _inventoryUI.Draw(spriteBatch);
            for (int i = 0; i < 9; i++)
            {
                if (_player.Inventory.GetCurrentSlot().Index == i)
                {
                    UIRectangle rect = new UIRectangle(Game1.ScreenWidth / 2 - 405 + 7 + ((15 + 75) * i), Game1.ScreenHeight - 85, 75, 75, Color.Red, _graphicsDevice);
                    spriteBatch.Draw(rect.Texture, rect.DestRect, Color.White);
                }
                else
                {
                    UIRectangle rect = new UIRectangle(Game1.ScreenWidth / 2 - 405 + 7 + ((15 + 75) * i), Game1.ScreenHeight - 85, 75, 75, Color.Black, _graphicsDevice);
                    spriteBatch.Draw(rect.Texture, rect.DestRect, Color.White);
                }
            }
        }


        public void Unload()
        {
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime, _sprites);
            _camera.Update();
            _camera.Follow(_player.Rect, _player.Origin, new(Game1.ScreenWidth, Game1.ScreenHeight));
            _inventoryUI.Update();
        }
    }
}
