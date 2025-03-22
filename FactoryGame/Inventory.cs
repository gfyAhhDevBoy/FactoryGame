using FactoryGame.Items;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace FactoryGame
{
    class Inventory
    {
        public Slot[] Slots { get; private set; }

        public int CurrentSlot;
        public bool Empty { get; private set; }

        public Inventory(int slots)
        {
            Slots = new Slot[slots];
            Empty = false;
            CurrentSlot = 0;
        }

        public void GoToSlot(int index)
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
                if (Slots[(int)index] == null)
                {
                    Slots[(int)index] = new Slot(item);
                }
            } else
            {
                for (int i = 0; i < Slots.Length; i++)
                {
                    if (Slots[i] == null)
                    {
                        Slots[i] = new Slot(item);
                        break;
                    }
                }
            }
        }

        public void AddItem(Slot item, int? index)
        {
            if (index != null)
            {
                if (Slots[(int)index] == null)
                {
                    Slots[(int)index] = item;
                }
            }
            else
            {
                for (int i = 0; i < Slots.Length; i++)
                {
                    if (Slots[i] == null)
                    {
                        Slots[i] = item;
                        break;
                    }
                }
            }
        }
    }
}
