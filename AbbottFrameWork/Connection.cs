using MySql.Data.MySqlClient;
using System;

namespace AbbottFrameWork
{
    public class Connection
    {
        private static string ConnectionString { get; set; }
        private static MySqlConnection Conn { get; set; }
        public static string GetConnectionString()
        {
            ConnectionString = "server = localhost; database = about; port = 3306; user id = root; password = root";
            return ConnectionString;
        }
        public static MySqlConnection GetConnection()
        {
            GetConnectionString();
            Conn = new MySqlConnection(ConnectionString);
            return Conn;
        }
    }
}
