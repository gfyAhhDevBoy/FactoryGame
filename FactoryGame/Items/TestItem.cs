using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FactoryGame.Util;

namespace FactoryGame.Items
{
    class TestItem : Item
    {
        public TestItem() : base(ContentManager.GetTexture("sword"), 4)
        {
        }
    }
}
