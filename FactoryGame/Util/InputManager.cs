using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FactoryGame.Util
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

    public class InputManager
    {
        public delegate void KeyEventHandler(object sender, KeboardEventArgs e);
        public delegate void MouseEventHandler(object sender, MouseEventArgs e);
        public delegate void MouseScrollEventHandler(object sender, ScrollWheelEventArgs e);
        public event KeyEventHandler KeyPressEvent;
        public event KeyEventHandler KeyUpEvent;
        public event MouseScrollEventHandler MouseScrollEvent;
        public event MouseEventHandler MouseButtonEvent;

        private KeyboardState _prevKb;
        private HashSet<Keys> _prevPressedKeys;

        private MouseState _prevMouse;
        private int _prevScrollWheelValue;

        public InputManager()
        {
            _prevKb = Keyboard.GetState();
            _prevPressedKeys = new(_prevKb.GetPressedKeys());
            _prevScrollWheelValue = Mouse.GetState().ScrollWheelValue;
            _prevMouse = Mouse.GetState();  
        }

        public void Update()
        {
            RaiseKeyPress();
            RaiseScrollWheelEvent();
            RaiseMouseButtonEvent();
        }

        private void RaiseMouseButtonEvent()
        {
            MouseState mouse = Mouse.GetState(); 

            if(mouse.LeftButton == ButtonState.Pressed && !(_prevMouse.LeftButton == ButtonState.Pressed))
            {
                MouseButtonEvent?.Invoke(this, new MouseEventArgs(MouseButtons.Left));
            }
            if (mouse.RightButton == ButtonState.Pressed && !(_prevMouse.RightButton == ButtonState.Pressed))
            {
                MouseButtonEvent?.Invoke(this, new MouseEventArgs(MouseButtons.Right));
            }

            _prevMouse = mouse;
        }

        private void RaiseKeyPress()
        {
            KeyboardState kb = Keyboard.GetState();
            Keys[] pressedKeys = kb.GetPressedKeys();

            foreach (var key in pressedKeys)
            {
                if (!_prevPressedKeys.Contains(key))
                {
                    KeyPressEvent?.Invoke(this, new KeboardEventArgs(key));
                }
            }

            _prevPressedKeys.Clear();
            foreach (var key in pressedKeys)
            {
                _prevPressedKeys.Add(key);
            }

            _prevKb = kb;
        }

        private void RaiseScrollWheelEvent()
        {
            MouseState mouse = Mouse.GetState();
            if(mouse.ScrollWheelValue > _prevScrollWheelValue)
            {
                MouseScrollEvent?.Invoke(this, new ScrollWheelEventArgs(ScrollWheelDirection.Up));
            } 
            if(mouse.ScrollWheelValue < _prevScrollWheelValue)
            {
                MouseScrollEvent?.Invoke(this, new ScrollWheelEventArgs(ScrollWheelDirection.Down));
            }

            _prevScrollWheelValue = mouse.ScrollWheelValue;
        }
    }

    public class KeboardEventArgs
    {
        public KeboardEventArgs(Keys key) { Key = key; }
        public Keys Key { get; }
    }
    public class MouseEventArgs
    {
        public MouseEventArgs(MouseButtons mouseButton) { MouseButton = mouseButton; }
        public MouseButtons MouseButton { get; }
    }
    public class ScrollWheelEventArgs
    {
        public ScrollWheelEventArgs(ScrollWheelDirection dir) {  Dir = dir; }
        public ScrollWheelDirection Dir { get; }
    }
}
