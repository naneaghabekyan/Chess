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
        public bool GameStatus {  get; set; }
        public bool WinnerColor {  get; set; }
        private bool CurrentPlayer = true;
        
        


        public bool MakeMove(string position)
        {

            int _startcol;
            int _startrow;
            int _endcol;
            int _endrow;

            
            _startcol = position[0] - 'A';
            _startrow = 8 - (position[1] - '0');
            _endcol = position[2] - 'A';
            _endrow = 8 - (position[3] - '0');



            if (!(_board.MoveValidation(_startcol, _startrow, _endcol,_endrow, CurrentPlayer)))
            {
                return false;
            }

            if(_board.Mat(!CurrentPlayer))
            {
                WinnerColor = CurrentPlayer;
                GameStatus = true;
            }

            CurrentPlayer = !CurrentPlayer;
            return true;
        }


    }
}

