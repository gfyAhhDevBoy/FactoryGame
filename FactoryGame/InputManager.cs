using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FactoryGame
{
    public class InputManager
    {
        public delegate void KeyEventHandler(object sender, InputEventArgs e);
        public event KeyEventHandler KeyPressEvent;
        public event KeyEventHandler KeyUpEvent;

        private KeyboardState _prevKb;
        private HashSet<Keys> _prevPressedKeys;

        public InputManager()
        {
            _prevKb = Keyboard.GetState();
            _prevPressedKeys = new(_prevKb.GetPressedKeys());
        }

        public void Update()
        {
            RaiseKeyPress();
        }

        private void RaiseKeyPress()
        {
            KeyboardState kb = Keyboard.GetState();
            Keys[] pressedKeys = kb.GetPressedKeys();

            foreach (var key in pressedKeys)
            {
                if (!_prevPressedKeys.Contains(key))
                {
                    KeyPressEvent?.Invoke(this, new InputEventArgs(key));
                }
            }

            _prevPressedKeys.Clear();
            foreach (var key in pressedKeys)
            {
                _prevPressedKeys.Add(key);
            }

            _prevKb = kb;
        }
    }

    public class InputEventArgs
    {
        public InputEventArgs(Keys key) { Key = key; }
        public Keys Key { get; }
    }
}
