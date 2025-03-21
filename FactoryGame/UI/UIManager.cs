using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryGame.UI
{
    class UIManager
    {
        List<IUIElement> _elements;

        public UIManager()
        {
            _elements = new();
        }

        public void Update()
        {
            foreach(var element in _elements)
            {
                element.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var element in _elements)
            {
                element.Draw(spriteBatch);
            }
        }

        public void Add(IUIElement uiElement)
        {
            _elements.Add(uiElement);
        }
    }
}
