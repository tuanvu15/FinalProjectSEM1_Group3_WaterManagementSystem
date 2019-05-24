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
        public ManagersDAL(){
            connection = DBHelper.OpenConnection();
        }
        public Managers Login(string userName, string pass)
        {
            if(userName == null || pass == null)
            {
                return null;
            }
            
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select * from Managers where email = '" + userName +"'and pass ='"+ pass + "';";
            DBHelper.OpenConnection();
            reader = DBHelper.ExcQuery(query);

           


            Managers managers = null;
            if(reader.Read())
            {
                managers = GetManagers(reader);
            }
           
            DBHelper.CloseConnection();
            return managers;

        }
        private Managers GetManagers(MySqlDataReader reader)
        {
            Managers mag = new Managers();
            mag.ManagersID = reader.GetInt16("managers_id");
            mag.Pass = reader.GetString("pass");
            mag.FullName =reader.GetString("full_name");
            mag.UserName = reader.GetString("email");
            return mag;
        }
    }
}