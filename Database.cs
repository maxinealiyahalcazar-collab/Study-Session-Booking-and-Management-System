using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Study_Session
{
    public class Database
    {
        private static string connectionString = 
            "server=localhost;" +
            "database=ilearn_db;" +
            "user=root;" +
            "password=*Phoenix0301*";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

    }
}
