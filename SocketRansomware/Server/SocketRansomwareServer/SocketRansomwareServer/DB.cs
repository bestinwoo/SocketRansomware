using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SocketRansomwareServer
{
    class DB
    {
        private static string _server = "localhost";
        private static int _port = 3306;
        private static string _database = "client";
        private static string _id = "root";
        private static string _pw = "1111";

        static string _connectionAddress = string.Format("Server={0};Port={1};" +
                "Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);

        public MySqlConnection _connection { get; set; }

        //Lazy는 객체가 필요한 시점에 초기화가 이루어짐
        //멀티스레딩에 안전한 구조
        private static readonly Lazy<DB> lazy = new Lazy<DB>(() => new DB());
        private DB() { }
        public static DB Instance
        {
            get
            {
                return lazy.Value;
            }
        }
       
        public void CreateConnection()
        {
            if(_connection == null)
            {
                _connection = new MySqlConnection(_connectionAddress);
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if(_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
      
        public MySqlDataReader ExecuteQuery(string query)
        {
            if (_connection == null) CreateConnection();
            try
            {
                using (_connection)
                {
                    MySqlCommand command = new MySqlCommand(query, _connection);
                    MySqlDataReader table = command.ExecuteReader();
                    
                    return table;
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        } 

        public int ExecuteNonQuery(string query)
        {
            if (_connection == null) CreateConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(query, _connection);
                return command.ExecuteNonQuery();
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

    }
}
