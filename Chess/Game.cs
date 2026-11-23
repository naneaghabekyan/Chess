using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Chess
{
    public class Game
    {

        public Board _board = new Board(); 

        public Player GameLogic(Player p1, Player p2)
        {
            Player temp;
            bool flag = true;
            string _position;
            int _startcol;
            int _startrow;
            int _endcol;
            int _endrow;

            _board.PrintBoard();


            while (true)
            {
                temp = flag ? p1 : p2;

                if (_board.Shax(flag))
                {
                    Console.WriteLine("King is under shax!");
                }
                Console.Write($"{temp.Nickname}: Your move:  ");
                

                while (true)
                {
                    _position = Console.ReadLine();
                    _startcol = _position[0] - 'A';
                    _startrow = 8 - (_position[1] - '0');
                    _endcol = _position[2] - 'A';
                    _endrow = 8 - (_position[3] - '0');


                    if (_board.Move(_startcol, _startrow, _endcol,_endrow, flag))
                        break;

                    
                    Console.Write("Invalid move. Try again: ");
                }

                Console.Clear();

                _board.PrintBoard();

                if (_board.Mat(!flag))
                {
                    Console.WriteLine("This is MAT!");
                    Console.WriteLine($"{temp.Nickname}: Wins!  ");
                    return temp;
                }

                flag = !flag;
            }
        }
    }
}

