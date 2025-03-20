using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryGame.UI
{
    class TextElement : UIElement
    {
        public string Text;
        public TextElement(Vector2 position, string text) : base(position)
        {
            Text = text;
        }
    }
}
