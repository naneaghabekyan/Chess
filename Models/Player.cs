using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string PasswordHash {  get; set; }
        public int Rank { get; set; } = 100;
        
      
        public Player() { }
        public Player(string nick)
        {
            Nickname = nick;
        }
    }
}
