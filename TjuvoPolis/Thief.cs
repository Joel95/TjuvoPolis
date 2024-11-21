using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvoPolis
{
    internal class Thief : Player
    {
        public override char Symbol => 'T';

        public override string CollidesWith(Player player, Random rnd)
        {
            if (player is Medborgare && player.Inventory.Count > 0)
            {
                int index = rnd.Next(player.Inventory.Count);
                string stolenItem = player.Inventory[index];
                Inventory.Add (player.Inventory[index]);
                Inventory.Add(stolenItem);
                player.Inventory.RemoveAt(index);
                //return $"{Meddelande.Rånad}: {stolenItem}";
            }
            if (player is Polis && Inventory.Count > 0)
            {
                player.Inventory.AddRange(Inventory);
                Inventory.Clear();
                return Meddelande.Rånad;
            }
            return null;
        }
    }
}
