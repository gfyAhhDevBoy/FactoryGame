using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FactoryGame.Util;

namespace FactoryGame.Items
{
    class TestItem : Item
    {
        public TestItem(Player player) : base(ContentManager.GetTexture("sword"), player, 4)
        {
        }
    }
}
