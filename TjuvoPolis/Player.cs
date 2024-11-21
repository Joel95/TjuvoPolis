using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvoPolis
{
    internal abstract class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int DirectionX { get; set; }

        public int DirectionY { get; set; }

        public virtual char Symbol { get; }

        public abstract string CollidesWith(Player player, Random rnd);
        public List<string> Inventory { get; set; } = new List<string>();
    }
}
