using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryGame.Items
{
    class Slot
    {
        private Inventory _inventory;
        private Item _item;

        public Slot(Item item)
        {
            _item = item;
        }
    }
}
