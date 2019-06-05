using System;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class ManagersDAL
    {
        private MySqlConnection connection;
        private string query;
        private MySqlDataReader reader;
        // DBHelper db = DBHelper.GetInstance();
        public ManagersDAL()
        {
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public Managers Login(string userName, string pass)
        {
            query = @"select * from Managers where email = '" + userName + "'and pass ='" + pass + "';";
            reader = DBHelper.ExecQuery(query, connection);
            Managers managers = null;
            if (reader.Read())
            {
                managers = GetManagers(reader);
            }
            connection.Close();
            return managers;
        }
        private Managers GetManagers(MySqlDataReader reader)
        {
            Managers mag = new Managers();
            mag.ManagersID = reader.GetInt32("managers_id");
            mag.Pass = reader.GetString("pass");
            mag.FullName = reader.GetString("full_name");
            mag.UserName = reader.GetString("email");
            return mag;
        }
    }
}