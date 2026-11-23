using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models;
using Data;

namespace Chess
{
    public abstract class Match
    {
        public int ID {  get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Player Winner { get; set; }

        public Game NewGame { get; set; }
        public MatchReposotory History = new MatchReposotory();

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Match(Player p1, Player p2)
        {
            Player1 = p1;
            Player2 = p2;

            NewGame = new Game();
        }
        public virtual void Start() 
        {
            StartTime = DateTime.Now;
        }
        public virtual void End()
        {
            EndTime = DateTime.Now;

            if (NewGame.WinnerColor == true)
            {
                Winner = Player1;
            }
            else
            {
                Winner = Player2;
            }

            int DatabaseID = History.AddMatch(
                GetMatchType(),
                StartTime,
                EndTime
            );

            History.AddMatchPlayer(DatabaseID, Player1.Id,
                Winner == Player1 ? "Win" : "Lose");

            History.AddMatchPlayer(DatabaseID, Player2.Id,
                Winner == Player2 ? "Win" : "Lose");
        }

        public abstract string GetMatchType();

    }
}


