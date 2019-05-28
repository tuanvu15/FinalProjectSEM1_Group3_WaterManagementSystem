using System;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DBHelper 
    {
        private static volatile DBHelper instance;
        static object key = new object();
        public static DBHelper Instance{
            get{
                if (instance == null)
                {
                    lock (key)
                    {
                        instance = new DBHelper();
                    }
                }
                return instance;
            }
        }
        //  private static volatile DBHelper instance = new DBHelper();
        private DBHelper(){}
        // public static DBHelper GetInstance()
        // {
        //     return instance;
        // }
        private  MySqlConnection connection;

         public  MySqlConnection GetConnection()
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
          
        }
         public  MySqlConnection OpenConnection(){
          
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
        public  void CloseConnection()
        {
           
               if(connection != null)
            {
                connection.Close();
            } 
            
            
            
        }
         public  MySqlDataReader ExcQuery(string query)
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

