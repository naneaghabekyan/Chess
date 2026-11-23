using Data;
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
        public override void End()
        {
            base.End();
            Winner.Rank += 80;
            PlayerRepository players = new PlayerRepository();
            players.UpdateRank(Winner);
        }

        public override string GetMatchType()
        {
            return "ranked";
        }
    }
}