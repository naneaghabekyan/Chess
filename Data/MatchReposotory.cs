using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Models; 

namespace Data
{
    public class MatchReposotory
    {
        private DatabaseConnection db = new DatabaseConnection();

        public int AddMatch(string type, DateTime startTime, DateTime endTime)
        {
            using (SqlConnection connection = db.CreateConnection())
            {
                connection.Open();

                string query = "INSERT INTO Matches (MatchType, StartTime, EndTime) OUTPUT INSERTED.MatchId VALUES (@type, @stime, @etime)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@stime", startTime);
                    command.Parameters.AddWithValue("@etime", endTime);

                    return (int)command.ExecuteScalar();  
                }
            }
        }

        public void AddMatchPlayer(int matchId, int playerId, string result)
        {
            using (SqlConnection connection = db.CreateConnection())
            {
                connection.Open();

                string query = "INSERT INTO MatchPlayers (MatchId, PlayerId, Result) VALUES (@matchId, @playerId, @result)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@matchId", matchId);
                    command.Parameters.AddWithValue("@playerId", playerId);
                    command.Parameters.AddWithValue("@result", result);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<MatchHistory> GetMatchHistory()
        {
            List<MatchHistory> history = new List<MatchHistory>();
            using (SqlConnection connection = db.CreateConnection())
            {
                connection.Open();

                string query = @"SELECT m.MatchType, m.StartTime, m.EndTime, p.Nickname 
                                 FROM Matches m
                                 Join MatchPlayers mp On mp.MatchId = m.MatchId
                                 Join Players p On p.PlayerId = mp.PlayerId
                                 Where mp.Result = 'Win'";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                   
                    while (reader.Read())
                    {
                        MatchHistory temp = new MatchHistory();

                        temp.MatchType = reader["MatchType"].ToString();
                        temp.StartTime = (DateTime)reader["StartTime"];
                        temp.EndTime = (DateTime)reader["EndTime"];
                        temp.Winner = reader["Nickname"].ToString();

                        history.Add(temp);

                    }
                    return history;
                }
            }
        }
    }
}
