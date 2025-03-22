using System.Collections.Generic;
using System.Net.Http.Headers;

namespace FactoryGame.Items
{
    class Inventory
    {
        public Item[] Items { get; private set; }

        public int CurrentSlot;
        public bool Empty { get; private set; }

        public Inventory(int slots)
        {
            Items = new Item[slots];
            Empty = false;
            CurrentSlot = 0;
        }

        public void GoToSlot(int index)
        {
            if(index > Items.Length - 1)
            {
                CurrentSlot = Items.Length - 1;
            } else if(index < 0)
            {
                CurrentSlot = 0;
            } else
            {
                CurrentSlot = index;
            }

        }

        public Item GetCurrentSlot()
        {
            return Items[CurrentSlot];
        }

        public void NextSlot()
        {
            if (CurrentSlot < Items.Length - 1)
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
                if(index > Items.Length - 1)
                {
                    return;
                }
                if(index < 0)
                {
                    return;
                }
                if (Items[(int)index] == null)
                {
                    Items[(int)index] = item;
                }
            } else
            {
                for (int i = 0; i < Items.Length; i++)
                {
                    if (Items[i] == null)
                    {
                        Items[i] = item;
                        break;
                    }
                }
            }
        }
    }
}
