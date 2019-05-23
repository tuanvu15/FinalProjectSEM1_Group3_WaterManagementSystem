using System;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class  ManagersDAL
    {
        private string query;
        private MySqlDataReader reader;
        public Managers Login(string email, string pass)
        {
            if(email == null || pass == null)
            {
                return null;
            }
            query = @"select * from Managers where email = '" + email +"'and pass ='"+ pass + "';";
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
            mag.ManagersID = reader.GetInt32("managers_id");
            mag.Pass = reader.GetString("pass");
            mag.FullName =reader.GetString("full_name");
            // mag.UserName = reader.GetString("user_name");
            return mag;
        }
    }
}