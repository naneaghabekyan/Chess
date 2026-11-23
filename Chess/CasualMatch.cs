using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models;

namespace Chess
{
    public class CasualMatch : Match
    {
        public CasualMatch(Player p1, Player p2)
        : base(p1, p2)
        {
        }
        public override Player GamePlay()
        {
            Game newGame = new Game();

           return newGame.GameLogic(Player1, Player2);
        }

    }
}