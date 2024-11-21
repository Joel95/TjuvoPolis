using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TjuvoPolis
{
    internal class Polis : Medborgare
    {
        public override char Symbol => ( 'P' );

        public override string CollidesWith(Player player, Random rnd)
        {
            if (player is Thief && player.Inventory.Count > 0)
            {
                Console.WriteLine($"Polis tar Thief: {player.Inventory.Count} items");
                Inventory.AddRange(player.Inventory);
                player.Inventory.Clear();
                return Meddelande.Arresterad;
            }
            return null;
            {
                if (player is Thief && player.Inventory.Count > 0)
                {
                    Inventory.AddRange(player.Inventory);
                    player.Inventory.Clear();
                    return Meddelande.Arresterad;
                }
                return null;
            }
        }


        //public override string CollidesWith(Player player, Random rnd)
        //{
        //    if (player is Thief && player.Inventory.Count > 0)
        //    {
        //        Inventory.AddRange(player.Inventory);
        //        player.Inventory.Clear();
        //        return Meddelande.Arresterad;
        //    }
        //    return null;
        //}


    }
}
