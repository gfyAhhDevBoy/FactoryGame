using Microsoft.Xna.Framework.Graphics;
using System;
using None = FactoryGame.Items.Air;

namespace FactoryGame.Items
{
    class Inventory
    {
        public Slot[] Slots { get; private set; }

        public int CurrentSlot;
        public bool Full { get; private set; }
        Player _player;

        public Inventory(int slots, Player player)
        {
            Slots = new Slot[slots];
            _player = player;
            for (int i = 0; i < Slots.Length; i++)
            {
                Slots[i] = new(new None(_player), i);
            }
            Full = false;
            CurrentSlot = 0;
        }

        public void Update()
        {
            bool full = false;
            foreach(var slot in Slots)
            {
                if(slot.GetItem() is None)
                {
                    full = false;
                } else if(slot.GetItem() is not None)
                {
                    full = true;
                }
            }

            if(full)
            {
                Full = true;
            }
        }

        public void SetSlot(int index)
        {
            if(index > Slots.Length - 1)
            {
                CurrentSlot = Slots.Length - 1;
            } else if(index < 0)
            {
                CurrentSlot = 0;
            } else
            {
                CurrentSlot = index;
            }

        }

        public Slot GetCurrentSlot()
        {
            return Slots[CurrentSlot];
        }

        public void NextSlot()
        {
            if (CurrentSlot < Slots.Length - 1)
                CurrentSlot++;
        }

        public void PreviousSlot()
        {
            if(CurrentSlot > 0)
            {
                CurrentSlot--;
            }
        }

        public void SetItem(Item item, int index)
        {
            if (!(index > Slots.Length - 1) && !(index < 0))
            {
                Slots[index].SetItem(item);
            }
        }

        public void AddItem(Item item)
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].GetItem() is None)
                {
                    Slots[i].SetItem(item);
                    break;
                }
            }
        }

        public Slot GetSlotAtIndex(int index)
        {
            if(!(index < 0) && !(index > Slots.Length - 1))
            {
                return Slots[index];
            } else
            {
                throw new IndexOutOfRangeException("Inventory Index out of bounds");
            }
        }

    }
    class Slot
    {
        private Inventory _inventory;
        private Item _item;
        public int Index;

        public Slot(Item item, int index)
        {
            _item = item;
            Index = index;
        }

        public Item GetItem() { return _item; }
        public void SetItem(Item item) { _item = item; }
        public void RemoveItem() { _item = null; }

        public override string ToString()
        {
            return string.Format("Item Name: {0}, Slot No.: {1}", _item.Name, Index);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(_item is not Air)
            {
                _item.Draw(spriteBatch, new());
            }
        }
    }
}
