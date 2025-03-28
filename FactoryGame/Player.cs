using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using SurvivalGame.Items;
using System.Diagnostics;
using SurvivalGame.Util;

namespace SurvivalGame
{
    class Player : Sprite
    {
        Vector2 _movement;
        private float _moveSpeed;
        private readonly float OriginalSpeed = 220f;
        private float _sprintSpeed;
        private bool _sprinting;
        private float _stamina;

        public Vector2 Origin;
        public Vector2 ItemOrigin;

        public SpriteEffects Rotation;

        public Inventory Inventory;

        InputManager _input;

        public Player(Texture2D texture, Vector2 position, Vector2 scale) : base(texture, position, scale)
        {
            _moveSpeed = OriginalSpeed;
            _sprintSpeed = 420f;
            _sprinting = false;
            _stamina = 100f;

            _movement = Vector2.Zero;
            
            Origin = new(Rect.Width / 2, Rect.Height / 2);
            ItemOrigin = new((int)Game1.ScreenWidth / 2 - 60 - Rect.Width / 2, (int)Game1.ScreenHeight / 2 - Rect.Height / 2 - 10);
            Inventory = new(9, this, Game1.Instance.GraphicsDevice);

            _input = new();
            _input.KeyPressEvent += HandleKeyInput;
            _input.MouseScrollEvent += HandleScrollWheelInput;
            _input.MouseButtonEvent += HandleMouseButtonInput;

        }

        private void HandleMouseButtonInput(object sender, MouseEventArgs e)
        {
            if(e.MouseButton == MouseButtons.Left)
            {
                Inventory.GetCurrentSlot().GetItem().Interact();
            }
        }

        private void HandleScrollWheelInput(object sender, ScrollWheelEventArgs e)
        {
            if(e.Dir == ScrollWheelDirection.Up)
            {
                Inventory.NextSlot();
            }
            if(e.Dir == ScrollWheelDirection.Down)
            {
                Inventory.PreviousSlot();
            }
        }

        private void HandleKeyInput(object sender, KeboardEventArgs e)
        {
            if (e.Key == Keys.Right)
            {
                Inventory.NextSlot();
            }
            if(e.Key == Keys.Left)
            {
                Inventory.PreviousSlot();
            }
        }

        public void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _input.Update();

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
            Position.Y += _movement.Y * _moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (var sprite in sprites)
            {
                if (sprite.Rect.Intersects(Rect))
                {
                    Position.Y -= _movement.Y * _moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            foreach (var tree in trees)
            {
                if (tree.TrunkRect.Intersects(Rect))
                {
                    Position.Y -= _movement.Y * _moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _movement.X -= 1;
                Rotation = SpriteEffects.None;
                ItemOrigin = new((int)Game1.ScreenWidth / 2 - 60 - Rect.Width / 2, (int)Game1.ScreenHeight / 2 - Rect.Height / 2 - 10);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _movement.X += 1;
                Rotation = SpriteEffects.FlipHorizontally;
                ItemOrigin = new((int)Game1.ScreenWidth / 2 + 30 - Rect.Width / 2, (int)Game1.ScreenHeight / 2 - Rect.Height / 2 - 10);
            }
            if (_movement != Vector2.Zero)
            {
                _movement.Normalize();
            }

            Position.X += _movement.X * _moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (var sprite in sprites)
            {
                if (sprite.Rect.Intersects(Rect))
                {
                    Position.X -= _movement.X * _moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            foreach (var tree in trees)
            {
                if (tree.TrunkRect.Intersects(Rect))
                {
                    Position.X -= _movement.X * _moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) && _stamina > 0)
            {
                _moveSpeed = _sprintSpeed;
                _stamina -= 0.75f;
            }
            else
            {
                _moveSpeed = OriginalSpeed;
            }

            if (!Keyboard.GetState().IsKeyDown(Keys.LeftShift) && _stamina < 100)
            {
                _stamina += 0.3f;
            }


            Debug.WriteLine(Inventory.GetCurrentSlot().ToString());
            Debug.WriteLine($"Stamina: {_stamina}");

        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            Rectangle dest = new(
                Rect.X + (int)offset.X,
                Rect.Y + (int)offset.Y,
                Rect.Width,
                Rect.Height
            );
            
            spriteBatch.Draw(_texture, dest, null, Color.White, 0f, new(), Rotation, 0f);
            //_inventory.GetCurrentSlot().Draw(spriteBatch, offset);
            //base.Draw(spriteBatch, camera);
        }
    }
}
