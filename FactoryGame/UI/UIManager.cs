using Microsoft.Xna.Framework;
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
        protected List<IUIElement> _elements;

        public UIManager()
        {
            _elements = new();
        }

        public virtual void Update()
        {
            foreach(var element in _elements)
            {
                element.Update();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var element in _elements)
            {
                element.Draw(spriteBatch);
            }
        }

        public virtual void Add(IUIElement uiElement) => _elements.Add(uiElement);
        
    }
}
