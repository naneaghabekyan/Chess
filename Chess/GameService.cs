using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace Chess
{
    public class GameService
    {

        private Queue<Player> queue = new Queue<Player>();
        private PlayerRepository Players = new PlayerRepository();
        private MatchReposotory History = new MatchReposotory();
        private Dictionary<int, Match> ActiveMatches = new Dictionary<int, Match>();

        private int MatchID = 1;

        public void RegisterPlayer(Player player)
        {
            if (Players.CheckPlayerExists(player))
            {
                throw new PlayerExistsException("Player already exists!");
            }

            player.Id = Players.AddPlayer(player);

        }

        public void AddQueue(Player player)
        {
            if (Players.CheckPlayerExists(player))
            {
                queue.Enqueue(player);
            }
            else
            {
                throw new PlayerDoesNotExistException("Player does not exist!");
            }
        }


        public Match JoinMatch(string matchType)
        { 
            if (queue.Count < 2)
            {
                throw new NotEnoughPlayersException("There are not enough players to start the match!");
            }
            else
            {
                Player p1 = queue.Dequeue();
                Player p2 = queue.Dequeue();

                Match match;
                if (matchType.ToLower() == "ranked")
                {
                    match = new RankedMatch(p1, p2);
                }
                else
                {
                    match = new CasualMatch(p1, p2);
                }
                match.ID = MatchID;
                ActiveMatches.Add(match.ID, match);

                MatchID++;
                return match;
           
            }
        }

        public Match StartMatch(int id)
        {
            Match match = ActiveMatches[id];

            match.Start();

            return match;
        }

        public bool MakeMove(int id, string pos)
        {
            Match match = ActiveMatches[id];

            bool result = match.NewGame.MakeMove(pos);

            if (result && match.NewGame.GameStatus)
            {
                match.End();
            }

            return result;
        }

        public bool GameIsOver(int id)
        {
            Match match = ActiveMatches[id];
            return match.NewGame.GameStatus;
        }

        public List<MatchHistory> ShowHistory()
        {
            return History.GetMatchHistory();
        }

       

        public List<Player> ShowLeaderBoard()
        {
           return Players.GetLeaderBoard();
        }
    }
}