using SurvivalGame.UI;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using None = SurvivalGame.Items.Air;
using System.Collections.Generic;

namespace SurvivalGame.Items
{
    class Inventory
    {
        public Slot[] Slots { get; private set; }


        public int CurrentSlot;
        public bool Full { get; private set; }
        Player _player;

        UIManager _ui;

        GraphicsDevice _graphicsDevice;

        public Inventory(int slots, Player player, GraphicsDevice graphicsDevice)
        {
            Slots = new Slot[slots];
            _graphicsDevice = graphicsDevice;
            _player = player;
            for (int i = 0; i < Slots.Length; i++)
            {
                Slots[i] = new(new None(_player), i);
            }
            Full = false;
            CurrentSlot = 0;
            _ui = new();
            _ui.Add(new UIRectangle(Game1.ScreenWidth / 2 - 412, Game1.ScreenHeight - 100, 825, 100, Color.DarkGray, _graphicsDevice));

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _ui.Draw(spriteBatch);
            DrawHotbarSlots(spriteBatch);
        }

        private void DrawSlotArray(int x, int y, int lengthX, int heightY, SpriteBatch spriteBatch)
        {
            for (int j = 0; j < heightY; j++)
            {
                for (int i = 0; i < lengthX; i++)
                {
                    Vector2 pos = new(x + 90 * i, y + (90 * j));

                    UIRectangle rect = new UIRectangle(pos, 75, 75, Color.Black, _graphicsDevice);
                    spriteBatch.Draw(rect.Texture, rect.DestRect, Color.White);

                    if (Slots[i].GetItem() is not None)
                    {
                        Rectangle rect1 = new((int)pos.X, (int)pos.Y, 75, 75);
                        spriteBatch.Draw(Slots[i].GetItem().GetTexture(), rect1, Color.White);
                    }
                }
            }
        }

        /*private void DrawSlotArray(int x, int y, int lengthX, int heightY, SpriteBatch spriteBatch)
        {
            for (int j = 0; j < heightY; j++)
            {
                for (int i = 0; i < lengthX; i++)
                {
                    Vector2 pos = new(Game1.ScreenWidth / 2 - 405 + 7 + 90 * i, Game1.ScreenHeight / 2 + (90 * j));

                    UIRectangle rect = new UIRectangle(pos, 75, 75, Color.Black, _graphicsDevice);
                    spriteBatch.Draw(rect.Texture, rect.DestRect, Color.White);

                    if (HotbarSlots[i].GetItem() is not None)
                    {
                        Rectangle rect1 = new(Game1.ScreenWidth / 2 - 405 + 7 + ((15 + 75) * i), Game1.ScreenHeight / 2 * j, 75, 75);
                        spriteBatch.Draw(HotbarSlots[i].GetItem().GetTexture(), rect1, Color.White);
                    }
                }
            }
        }*/

        private void DrawHotbarSlots(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 9; i++)
            {

                if (GetCurrentSlot().Index == i)
                {
                    UIRectangle rect = new UIRectangle(Game1.ScreenWidth / 2 - 405 + 7 + ((15 + 75) * i), Game1.ScreenHeight - 85, 75, 75, Color.Red, _graphicsDevice);
                    spriteBatch.Draw(rect.Texture, rect.DestRect, Color.White);
                }
                else
                {
                    UIRectangle rect = new UIRectangle(Game1.ScreenWidth / 2 - 405 + 7 + ((15 + 75) * i), Game1.ScreenHeight - 85, 75, 75, Color.Black, _graphicsDevice);
                    spriteBatch.Draw(rect.Texture, rect.DestRect, Color.White);
                }

                if (Slots[i].GetItem() is not None)
                {
                    Rectangle rect = new(Game1.ScreenWidth / 2 - 405 + 7 + ((15 + 75) * i), Game1.ScreenHeight - 85, 75, 75);
                    spriteBatch.Draw(Slots[i].GetItem().GetTexture(), rect, Color.White);
                }
            }
        }

        private void DrawHotbarSlots(int x, int y, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 9; i++)
            {
                Vector2 pos = new(x + 90 * i, Game1.ScreenHeight - 85);

                if (GetCurrentSlot().Index == i)
                {
                    UIRectangle rect = new UIRectangle(pos, 75, 75, Color.Red, _graphicsDevice);
                    spriteBatch.Draw(rect.Texture, rect.DestRect, Color.White);
                }
                else
                {
                    UIRectangle rect = new UIRectangle(pos, 75, 75, Color.Black, _graphicsDevice);
                    spriteBatch.Draw(rect.Texture, rect.DestRect, Color.White);
                }

                if (Slots[i].GetItem() is not None)
                {
                    Rectangle rect = new((int)pos.X, (int)pos.Y, 75, 75);
                    spriteBatch.Draw(Slots[i].GetItem().GetTexture(), rect, Color.White);
                }
            }
        }

        public void Update()
        {
            bool full = false;
            foreach (var slot in Slots)
            {
                if (slot.GetItem() is None)
                {
                    full = false;
                }
                else if (slot.GetItem() is not None)
                {
                    full = true;
                }
            }

            if (full)
            {
                Full = true;
            }


        }

        public void GoToSlot(int index)
        {
            if (index < Slots.Length && index >= 0)
            {
                CurrentSlot = index;
            }

        }

        public Slot GetCurrentSlot() => Slots[CurrentSlot];

        public void NextSlot()
        {
            if (CurrentSlot < Slots.Length - 1)
                CurrentSlot++;
            else
                CurrentSlot = 0;
        }

        public void PreviousSlot()
        {
            if (CurrentSlot > 0)
                CurrentSlot--;
            else
                CurrentSlot = Slots.Length - 1;
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
            if (!(index < 0) && !(index > Slots.Length - 1))
            {
                return Slots[index];
            }
            else
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

        public Item GetItem() => _item;
        public void SetItem(Item item) => _item = item;
        public void RemoveItem(Player player) => _item = new None(player);

        public override string ToString()
            => string.Format("Item Name: {0}, Slot No.: {1}", _item.Name, Index);


        public void Draw(SpriteBatch spriteBatch)
        {
            if (_item is not Air)
            {
                _item.Draw(spriteBatch);
            }
        }
    }
}
