using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SurvivalGame.Util
{
    public enum ScrollWheelDirection
    {
        Up,
        Down
    }
     
    public enum MouseButtons
    {
        Left,
        Right
    }

    public static class InputManager
    {
        public delegate void KeyEventHandler(object sender, KeboardEventArgs e);
        public delegate void MouseEventHandler(object sender, MouseEventArgs e);
        public delegate void MouseScrollEventHandler(object sender, ScrollWheelEventArgs e);
        public static event KeyEventHandler KeyPressEvent;
        public static event KeyEventHandler KeyUpEvent;
        public static event MouseScrollEventHandler MouseScrollEvent;
        public static event MouseEventHandler MouseButtonEvent;

        private static KeyboardState _prevKb;
        private static HashSet<Keys> _prevPressedKeys;

        private static MouseState _prevMouse;
        private static int _prevScrollWheelValue;

        static InputManager()
        {
            _prevKb = Keyboard.GetState();
            _prevPressedKeys = new(_prevKb.GetPressedKeys());
            _prevScrollWheelValue = Mouse.GetState().ScrollWheelValue;
            _prevMouse = Mouse.GetState();  
        }

        public static void Update()
        {
            RaiseKeyPress();
            RaiseScrollWheelEvent();
            RaiseMouseButtonEvent();
        }

        private static void RaiseMouseButtonEvent()
        {
            MouseState mouse = Mouse.GetState(); 

            if(mouse.LeftButton == ButtonState.Pressed && !(_prevMouse.LeftButton == ButtonState.Pressed))
            {
                MouseButtonEvent?.Invoke(typeof(InputManager), new MouseEventArgs(MouseButtons.Left));
            }
            if (mouse.RightButton == ButtonState.Pressed && !(_prevMouse.RightButton == ButtonState.Pressed))
            {
                MouseButtonEvent?.Invoke(typeof(InputManager), new MouseEventArgs(MouseButtons.Right));
            }

            _prevMouse = mouse;
        }

        private static void RaiseKeyPress()
        {
            KeyboardState kb = Keyboard.GetState();
            Keys[] pressedKeys = kb.GetPressedKeys();

            foreach (var key in pressedKeys)
            {
                if (!_prevPressedKeys.Contains(key))
                {
                    KeyPressEvent?.Invoke(typeof(InputManager), new KeboardEventArgs(key));
                }
            }

            _prevPressedKeys.Clear();
            foreach (var key in pressedKeys)
            {
                _prevPressedKeys.Add(key);
            }

            _prevKb = kb;
        }

        private static void RaiseScrollWheelEvent()
        {
            MouseState mouse = Mouse.GetState();
            if(mouse.ScrollWheelValue > _prevScrollWheelValue)
            {
                MouseScrollEvent?.Invoke(typeof(InputManager), new ScrollWheelEventArgs(ScrollWheelDirection.Up));
            } 
            if(mouse.ScrollWheelValue < _prevScrollWheelValue)
            {
                MouseScrollEvent?.Invoke(typeof(InputManager), new ScrollWheelEventArgs(ScrollWheelDirection.Down));
            }

            _prevScrollWheelValue = mouse.ScrollWheelValue;
        }
    }

    public class KeboardEventArgs
    {
        public KeboardEventArgs(Keys key) => Key = key; 
        public Keys Key { get; }
    }
    public class MouseEventArgs
    {
        public MouseEventArgs(MouseButtons mouseButton) => MouseButton = mouseButton;
        public MouseButtons MouseButton { get; }
    }
    public class ScrollWheelEventArgs
    {
        public ScrollWheelEventArgs(ScrollWheelDirection dir) => Dir = dir;
        public ScrollWheelDirection Dir { get; }
    }
}
