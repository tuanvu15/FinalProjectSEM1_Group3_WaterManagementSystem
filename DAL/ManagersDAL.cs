using System;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class  ManagersDAL
    {
        private MySqlConnection connection;
        private string query;
        private MySqlDataReader reader;
        // DBHelper db = DBHelper.GetInstance();
        public ManagersDAL(){
            // connection = DBHelper.OpenConnection();
            
            // connection =DBHelper.Instance.OpenConnection();
                if (connection == null)
            {
                // connection = DBHelper.OpenConnection();
                connection = DBHelper.Instance.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection= DBHelper.Instance.OpenConnection();
                
            }
        }
         public Managers Login(string userName, string pass)
        {
            if(userName == null || pass == null)
            {
                return null;
            }
            
       
            query = @"select * from Managers where email = '" + userName +"'and pass ='"+ pass + "';";
            // DBHelper.OpenConnection();
            
            // reader = DBHelper.ExcQuery(query);
              reader = DBHelper.Instance.ExcQuery(query);
            Managers managers = null;
            try
            {
            //     if (connection == null)
            // {
            //     // connection = DBHelper.OpenConnection();
            //     connection = DBHelper.Instance.OpenConnection();
            // }
            // if (connection.State == System.Data.ConnectionState.Closed)
            // {
            //     connection.Open();
                
            // }
            MySqlCommand command = new MySqlCommand(query, connection);


            
            if(reader.Read())
            {
                managers = GetManagers(reader);
            }
           
            // DBHelper.CloseConnection();
            DBHelper.Instance.CloseConnection();
            
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("lỗi kết nối!");
                
                
            }
           return managers;

        }
        private Managers GetManagers(MySqlDataReader reader)
        {
            Managers mag = new Managers();
            mag.ManagersID = reader.GetInt32("managers_id");
            mag.Pass = reader.GetString("pass");
            mag.FullName =reader.GetString("full_name");
            mag.UserName = reader.GetString("email");
            return mag;
        }
    }
}