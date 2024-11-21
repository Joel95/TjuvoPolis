using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TjuvoPolis
{
    internal class Board
    {
        public Board(int SizeX, int SizeY, int NrOfThieves, int NrOfPolis, int NrOfMedborgare, Random Rnd)
        {
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            this.NrOfThieves = NrOfThieves;
            this.NrOfPolis = NrOfPolis;
            this.NrOfMedborgare = NrOfMedborgare;
            this. Rnd = Rnd;

            Players = new List<Player>();
            Meddelanden = new List<string>();

            ResetBoard();
        }
        public int SizeX { get; }
        public int SizeY { get; }

        public int NrOfThieves { get; }
        public int NrOfPolis { get; }
        public int NrOfMedborgare { get; }
        public Random Rnd { get; }
        protected List<Player> Players { get; set; }

        public List<string> Meddelanden { get; set; }

        public int Arresterade { get; private set; }

        public int Rånade { get; private set; }

        public void ResetBoard()
        {
            Players.Clear();

            CreatePlayers<Thief>(NrOfThieves);
            CreatePlayers<Polis>(NrOfPolis);
            CreatePlayers<Medborgare>(NrOfMedborgare);

        }

        protected void  CreatePlayers<T>(int count) where T : Player, new()
        {
            for (int i = 0; i < count; i++)
            {
                var pos = GetRandomXY();
                var direction = GetRandomDirection();

                var player = new T();
                player. X = pos.Item1;
                player. Y = pos.Item2;
                player.DirectionX = direction.Item1;
                player.DirectionY = direction.Item2;
                Players.Add(player);
                
            }
        }

        protected Tuple<int, int> GetRandomXY()
        {
            return new Tuple<int, int>(Rnd.Next(SizeX), Rnd.Next(SizeY));
        }
        protected Tuple<int, int> GetRandomDirection()
        {
            var direction = Rnd.Next(0, 8);
            switch (direction)
            { 
                    case 0: return new Tuple<int, int>(0, -1);
                    case 1: return new Tuple<int, int>(1, -1);
                    case 2: return new Tuple<int, int>(1, 0);
                    case 3: return new Tuple<int, int>(1, 1);
                    case 4: return new Tuple<int, int>(0, 1);
                    case 5: return new Tuple<int, int>(-1, 1);
                    case 6: return new Tuple<int, int>(-1, 0) ;
                    case 7: return new Tuple<int, int>(-1, -1);
            }

            return  new Tuple<int, int> (0, 0);

        }

        public void Update()
        {

            for (int i = 0; i < Players.Count; i++)
            {
                var player = Players[i];
                player.X += player.DirectionX;
                player.Y += player.DirectionY;


                player.X = player.X < 0 ? SizeX - 1 : player.X;
                player.Y = player.Y < 0 ? SizeY - 1 : player.Y;
                player.X = player.X >= SizeX ? 0 : player.X;
                player.Y = player.Y >= SizeY ? 0 : player.Y;

                for (int j = i - 1; j > 0; j--)
                {
                    if (player.X == Players[j].X && player.Y == Players[j].Y)
                    {
                        var med = player.CollidesWith(Players[j], Rnd);
                        if (med != null)
                        {
                            if (med == Meddelande.Rånad)
                                Rånade++;
                            if (med == Meddelande.Arresterad)
                                Arresterade++;

                            Meddelanden.Add(med);
                        }
                        Console.WriteLine();
                    }
                }
            }

            foreach (var player in Players)
            {
                player.X += player.DirectionX;
                player.Y += player.DirectionY;


                player.X = player.X < 0 ? SizeX - 1 : player.X;
                player.Y = player.Y < 0 ? SizeY - 1 : player.Y;
                player.X = player.X >= SizeX ? 0 : player.X;
                player.Y = player.Y >= SizeY ? 0 : player.Y;


            }


            for (int i = 0; i < Players.Count; i++)
            {
                var player = Players[i];

                for (int j = i + 1; j < Players.Count; j++)
                {
                    var otherPlayer = Players[j];
                    if (player.X == otherPlayer.X && player.Y == otherPlayer.Y)
                    {

                        var collisionMessage = player.CollidesWith(otherPlayer, Rnd);
                        if (!string.IsNullOrEmpty(collisionMessage))
                        {
                            Meddelanden.Add(collisionMessage);


                            if (collisionMessage.Contains(Meddelande.Rånad))
                            {
                                Rånade++;
                            }
                            if (collisionMessage.Contains(Meddelande.Arresterad))
                            {
                                Arresterade++;
                            }
                        }
                    }
                }
            }
        }

        public void Clear()
        {
            Meddelanden.Clear();

            foreach (var player in Players)
            {
                Console.SetCursorPosition(player.X, player.Y);
                Console.Write(" ");
            }
        }
            
        public void Draw()
        {

            foreach (var player in Players)
            {
                Console.SetCursorPosition(player.X, player.Y);
                Console.Write(player.Symbol);
            }
        }
    }  
}
        
    




    

