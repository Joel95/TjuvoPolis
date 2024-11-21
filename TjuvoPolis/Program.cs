namespace TjuvoPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(100, 25, 20, 10, 30, new Random());


           
            Console.CursorVisible = false;

            while (true)
            {
                board.Clear();
                board.Update();
                board.Draw();

                Console.SetCursorPosition(0, 26);

                Console.WriteLine($"$ Antal rånade i staden:  { board.Rånade } ");
                Console.WriteLine($"antal tagna tjuvar: { board.Arresterade }" );

                    foreach (var item in board.Meddelanden)
                        Console.WriteLine(item);

                    if (board.Meddelanden.Count == 0)
                        Thread.Sleep(200);

                    else
                    {
                        Thread.Sleep(2000);
                        Console.Clear();
                        board.Meddelanden.Clear();
                    }
                
            }


        }
    }
}
