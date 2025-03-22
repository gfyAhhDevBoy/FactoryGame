using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using FactoryGame.Items;

namespace FactoryGame
{
    class Player : Sprite
    {
        Vector2 _movement;
        private readonly float speed = 220f;

        public Vector2 Origin;
        public Vector2 ItemOrigin;

        private SpriteEffects _rotation;

        private Inventory _inventory;

        public Player(Texture2D texture, Vector2 position, Vector2 scale) : base(texture, position, scale)
        {
            _movement = Vector2.Zero;
            
            Origin = new(Rect.Width / 2, Rect.Height / 2);
            ItemOrigin = new(Rect.Width - Game1.Instance.Camera.Position.X, Rect.Height / 2 - Game1.Instance.Camera.Position.Y);
            _inventory = new(9);
        }

        public void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _movement = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _movement.Y -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _movement.Y += 1;
            }
            if (_movement != Vector2.Zero)
            {
                _movement.Normalize();
            }
            Position.Y += _movement.Y * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (var sprite in sprites)
            {
                if (sprite.Rect.Intersects(Rect))
                {
                    Position.Y -= _movement.Y * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _movement.X -= 1;
                _rotation = SpriteEffects.None;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _movement.X += 1;
                _rotation = SpriteEffects.FlipHorizontally;
            }
            if (_movement != Vector2.Zero)
            {
                _movement.Normalize();
            }

            Position.X += _movement.X * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (var sprite in sprites)
            {
                if (sprite.Rect.Intersects(Rect))
                {
                    Position.X -= _movement.X * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime); 
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            Rectangle dest = new(
                Rect.X + (int)offset.X,
                Rect.Y + (int)offset.Y,
                Rect.Width,
                Rect.Height
            );
            
            spriteBatch.Draw(_texture, dest, null, Color.White, 0f, new(), _rotation, 0f);
            CurrentItem.Draw(spriteBatch, offset, _rotation);
            //base.Draw(spriteBatch, camera);
        }
    }
}
