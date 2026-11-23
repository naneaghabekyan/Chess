using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chess
{

    public class RankedMatch : Match
    {
        public RankedMatch(Player p1, Player p2)
        : base(p1, p2)
        {
        }
        public override Player GamePlay()
        {
            Game newGame = new Game();
            Player player = newGame.GameLogic(Player1, Player2);
            player.Rank += 80;
            return player;
        }

    }
}