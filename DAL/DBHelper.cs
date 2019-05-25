using System;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DBHelper 
    {
        private static MySqlConnection connection;

        public static MySqlConnection GetConnection()
        {
            try
            {
                 connection = new MySqlConnection
                {
                    ConnectionString = @"server = localhost;
                                        user id = root; password = 01652530159;
                                        port= 3306; database = projectData"

                };
                return connection;
            }
            catch 
            {
                
                return null;
            }
            // if(connection == null)
            // {
            //     connection = new MySqlConnection
            //     {
            //         ConnectionString = @"server = localhost;
            //                             user id = root; password = 01652530159;
            //                             port= 3306; database = projectData"

            //     };
            // }
            // return connection;
        }
        public static MySqlConnection OpenConnection(){
            // if(connection == null)
            // {
            //     GetConnection();
            // }
            // connection.Open();
            // return connection;
            try
            {
                if (connection == null)
                {
                    GetConnection();
                }
                connection.Open();
                return connection;
            }
            catch 
            {
                
                return null;
            }
        }
        public static void CloseConnection()
        {
           
               if(connection != null)
            {
                connection.Close();
            } 
            
            
            
        }
        public static MySqlDataReader ExcQuery(string query)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                return command.ExecuteReader();
            }
            catch 
            {
                return null;
            }
            
        }
    }
}

