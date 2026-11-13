using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class GameRoom
    {
        private Dictionary<string, Player> Players = new Dictionary<string, Player>();
        private Queue<Player> queue = new Queue<Player>();
        private Stack<MatchGame> History = new Stack<MatchGame>();


        // Add a player
        public void RegisterPlayer(Player player)
        {
            if (Players.ContainsKey(player.Nickname))
            {
                throw new PlayerExistsException("Player already exists:");
            }
            Players.Add(player.Nickname, player);

        }

        // Check if there is such a player
        private bool CheckPlayer(Player player)
        {
            if (Players.ContainsKey(player.Nickname))
            {
                return true;
            }
            else
            {
                throw new PlayerDoesNotExistException("The player doesn't exist!");
            }
        }


        // Add players to queue to start the match
        public void AddQueue(Player player)
        {
            if (CheckPlayer(player))
            {
                queue.Enqueue(player);
            }
        }

        // Join 2 players (if there are) to start the match
        public void JoinMatch(string matchType)
        { 
            if (queue.Count < 2)
            {
                throw new NotEnoughPlayersException("There are not enough players to start the match!");
            }
            else
            {
                Player p1 = queue.Dequeue();
                Player p2 = queue.Dequeue();
                MatchGame match;
                if (matchType.ToLower() == "ranked")
                {
                    match = new RankedMatch(p1, p2);
                }
                else
                {
                    match = new CasualMatch(p1, p2);
                }

                match.Start();
                match.GamePlay();
                match.End();

                History.Push(match);

            }
        }

        // Show the history of matches
        public void ShowHistory()
        {
            Console.WriteLine("The history of matches starting from the last match");
            foreach (MatchGame match in History)
            {
                Console.WriteLine($"{match.Player1.Nickname} vs {match.Player2.Nickname}\n");
            }
        }


        // Show the leaderboard
        public void ShowLeaderBoard()
        {
            Console.WriteLine("Leaderboard:\n");

            var sortedPlayers = Players.OrderByDescending(p => p.Value.Rank);

            int i = 1;

            foreach (var player in sortedPlayers)
            {
                Console.WriteLine($"{i}. {player.Value.Nickname} - Rank: {player.Value.Rank}");
                i++;
            }
        }
    }
}