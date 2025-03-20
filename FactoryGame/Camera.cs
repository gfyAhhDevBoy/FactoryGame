﻿using Microsoft.Xna.Framework;

namespace FactoryGame
{
    class Camera
    {
        public Vector2 Position;

        public Camera(Vector2 position)
        {
            Position = position;
        }

        public void Follow(Rectangle target, Vector2 screenSize)
        {
            Position = new Vector2(
                -target.X + (screenSize.X / 2 - target.Width / 2),
                -target.Y + (screenSize.Y / 2 - target.Height / 2)
            );
        }
    }
}
