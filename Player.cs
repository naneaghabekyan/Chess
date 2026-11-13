using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Player
    {
        public string Nickname { get; set; }
        public int Rank { get; set; } = 100;
        
      
        public Player(string nick)
        {
            Nickname = nick;

        }
    }
}
