using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvoPolis
{
    internal class Medborgare : Player
    {
        public override char Symbol => ('M');

        public Medborgare()
        {
            Inventory.Add("Kläder");
            Inventory.Add("Diamanter");
            Inventory.Add("Guld");
            Inventory.Add("Busskort");
        }

        public override string CollidesWith(Player player, Random rnd)
        {
            if (player is Thief && Inventory.Count > 0)
            {
                int index = rnd.Next(Inventory.Count);
                player.Inventory.Add(Inventory[index]);
                Inventory.RemoveAt(index);
                return Meddelande.Rånad;
            }
            return null;
        }


    }
}
