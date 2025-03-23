using System.Collections.Generic;
using System.Net.Http.Headers;

namespace FactoryGame.Items
{
    class Inventory
    {
        public Slot[] Slots { get; private set; }

        public int CurrentSlot;
        public bool Empty { get; private set; }
        Player _player;

        public Inventory(int slots, Player player)
        {
            Slots = new Slot[slots];
            _player = player;
            for (int i = 0; i < Slots.Length; i++)
            {
                Slots[i] = new(new Air(_player), i);
            }
            Empty = false;
            CurrentSlot = 0;
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

        public void AddItem(Item item, int? index)
        {
            if(index != null)
            {
                if(index > Slots.Length - 1)
                {
                    return;
                }
                if(index < 0)
                {
                    return;
                }
                if (Slots[(int)index].GetItem() == null)
                {
                    Slots[(int)index].SetItem(item);
                }
            } else
            {
                for (int i = 0; i < Slots.Length; i++)
                {
                    if (Slots[i].GetItem() == null)
                    {
                        Slots[i].SetItem(item);
                        break;
                    }
                }
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
    }
}
