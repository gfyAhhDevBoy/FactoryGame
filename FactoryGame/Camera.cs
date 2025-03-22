﻿using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace FactoryGame
{
    class Camera
    {
        public Vector2 Position;
        public int ZoomLevel;

        Util.InputManager input;

        public Camera(Vector2 position)
        {
            Position = position;
            ZoomLevel = 5;
            input = new();

            input.MouseScrollEvent += Input_MouseScrollEvent;
        }

        private void Input_MouseScrollEvent(object sender, Util.ScrollWheelEventArgs e)
        {
            if(e.Dir == Util.ScrollWheelDirection.Up)
            {
                if(ZoomLevel > 0)
                    ZoomLevel--;
            }
            else if(e.Dir== Util.ScrollWheelDirection.Down)
            {
                if(ZoomLevel > 5) 
                    ZoomLevel++;
            }
        }

        public void Update()
        {
            input.Update();

            Debug.WriteLine(ZoomLevel);
        }

        public void Follow(Rectangle target, Vector2 origin, Vector2 screenSize)
        {
            Position = new Vector2(
                -target.X + (screenSize.X / 2 - target.Width / 2),
                -target.Y + (screenSize.Y / 2 - target.Height / 2)
            );
        }
    }
}
