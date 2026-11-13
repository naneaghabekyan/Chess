using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess;

namespace Chess
{
    internal class Program
    {
        static void Main()
        {
            Player p1 = new Player("first");
            Player p2 = new Player("second");
            Player p3 = new Player("third");

            GameRoom newGameRoom = new GameRoom();
            try
            {
                newGameRoom.RegisterPlayer(p1);
                newGameRoom.RegisterPlayer(p2);
                newGameRoom.RegisterPlayer(p3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            newGameRoom.AddQueue(p1);
            newGameRoom.AddQueue(p2);
            newGameRoom.AddQueue(p3);
            newGameRoom.AddQueue(p2);
            newGameRoom.AddQueue(p3);


            Console.Write("Choose the match type (ranked or casual): ");
            newGameRoom.JoinMatch(Console.ReadLine());


        }
    }
}
