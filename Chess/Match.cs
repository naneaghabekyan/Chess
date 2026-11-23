using Chess;
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
    public abstract class Match
    {
        public int ID {  get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Match(Player p1, Player p2)
        {
            Player1 = p1;
            Player2 = p2;
        }
        public virtual void Start() 
        {
            StartTime = DateTime.Now;
        }
        public virtual void End() 
        {
            EndTime = DateTime.Now;
        }
        public abstract Player GamePlay();

    }
}


