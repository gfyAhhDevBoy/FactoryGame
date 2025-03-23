using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryGame.Items;

namespace FactoryGame.UI
{
    class InventoryUI : UIManager
    {

        public InventoryUI()
        {
            
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }

        public override void Add(IUIElement uiElement)
        {
            _elements.Add(uiElement);
        }

        public void Add(Inventory inventory)
        {

        }
    }
}
