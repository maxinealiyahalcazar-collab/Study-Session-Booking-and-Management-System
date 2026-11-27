using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Study_Session
{
    public class Database
    {
        private static readonly string connectionString = CreateConnectionString();

        private static string CreateConnectionString()
        {
            string password = Environment.GetEnvironmentVariable("ILEARN_DB_PASSWORD");

            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Database password is missing!");
            }

            return new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "oop_ilearn",
                UserID = "ilearn_app",
                Password = password
            }.ConnectionString;
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
