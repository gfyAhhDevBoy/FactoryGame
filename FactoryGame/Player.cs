using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FactoryGame
{
    class Player : Sprite
    {
        Vector2 _movement;
        private float _rotation;
        private readonly float speed = 220f;

        public Vector2 Origin;

        public Player(Texture2D texture, Vector2 position, Vector2 scale) : base(texture, position, scale)
        {
            _movement = Vector2.Zero;
            _rotation = 0;
            Origin = new(Rect.Width / 2, Rect.Height / 2);
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
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _movement.X += 1;
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

        public override void Draw(SpriteBatch spriteBatch, in Camera camera)
        {
            /*Rectangle dest = new(
                Rect.X + (int)offset.X,
                Rect.Y + (int)offset.Y,
                Rect.Width,
                Rect.Height
            );
            spriteBatch.Draw(_texture, dest, null, Color.White, _rotation, Origin, SpriteEffects.None, 0f);
*/
            base.Draw(spriteBatch, camera);
        }
    }
}
