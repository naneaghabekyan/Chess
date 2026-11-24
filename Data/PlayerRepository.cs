using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Threading;
using Microsoft.Data.SqlClient;
using Models;

namespace Data
{
    public class PlayerRepository
    {
        private DatabaseConnection db = new DatabaseConnection();

        public void AddPlayer(Player player)
        {
            using (SqlConnection connection = db.CreateConnection())
            {
                connection.Open();

                string query = "INSERT INTO Players (Nickname, Rank, PasswordHash) VALUES (@Nickname, @Rank, @PasswordHash)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nickname", player.Nickname);
                    command.Parameters.AddWithValue("@Rank", player.Rank);
                    command.Parameters.AddWithValue("@PasswordHash", player.PasswordHash);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Player CheckPlayerExists(string nickname)
        {
            using (SqlConnection connection = db.CreateConnection())
            {
                connection.Open();

                string query = "SELECT PlayerID, Nickname, Rank, PasswordHash FROM Players WHERE Nickname = @nik";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nik", nickname);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Player player = new Player();

                            player.Id = (int)reader["PlayerID"];
                            player.Nickname = reader["Nickname"].ToString();
                            player.Rank = (int)reader["Rank"];
                            player.PasswordHash = reader["PasswordHash"].ToString();

                            return player;
                        }

                        return null;
                    }
                }
            }
        }

        public void UpdateRank(Player player)
        {
            using (SqlConnection connaction = db.CreateConnection())
            {
                connaction.Open();
                string query = "Update Players Set Rank = @rank Where PlayerID = @id";
                using (SqlCommand command = new SqlCommand(query, connaction))
                {
                    command.Parameters.AddWithValue("@rank", player.Rank);
                    command.Parameters.AddWithValue("@id", player.Id);

                    command.ExecuteNonQuery();
                }

            }
        }

        public List<Player> GetLeaderBoard()
        {
            List<Player> players = new List<Player>();
           

            using (SqlConnection connaction = db.CreateConnection())
            {
                connaction.Open();
                string query = "Select PlayerID,Nickname,Rank From Players Order By Rank Desc";

                using (SqlCommand command = new SqlCommand(query, connaction))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Player temp = new Player();

                        temp.Id = (int)reader["PlayerID"];
                        temp.Nickname = reader["Nickname"].ToString();
                        temp.Rank = (int)reader["Rank"];

                        players.Add(temp);
             
                    }

                }

            }
            return players;
        }



    }
}
