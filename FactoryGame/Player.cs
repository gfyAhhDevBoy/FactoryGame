using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryGame
{
    class Player : Sprite
    {
        Vector2 _movement;

        private readonly float speed = 100f;

        public Player(Texture2D texture, Vector2 position, Vector2 scale) : base(texture, position, scale)
        {
            _movement = Vector2.Zero;
        }

        public void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _movement = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _movement.Y -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _movement.X -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _movement.Y += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _movement.X += 1;
            }

            if (_movement != Vector2.Zero)
            {
                _movement.Normalize();
            }

            Position += _movement * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach(var sprite in sprites)
            {
                if(sprite.Rect.Intersects(Rect))
                {
                    Position -= _movement * speed;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);   
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }

    class Camera
    {

    }
}
