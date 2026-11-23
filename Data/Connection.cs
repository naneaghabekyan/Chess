using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data
{

    public class DatabaseConnection
    {
        private string connectionString =
            @"Server=WIN-L7NUD5LD5HH\SQLEXPRESS;Database=ChessDataBase;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}