using SurvivalGame.Util;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalGame.Items
{
    internal class TestItem : Item
    {
        public TestItem(Player player) : base(ContentManager.GetTexture("sword"), player, "Sword", new(6,6))
        {
        }
    }
}
