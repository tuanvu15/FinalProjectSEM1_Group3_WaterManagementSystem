using System;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class MonthDAL
    {
        private string query;
        private MySqlConnection connection;
        private MySqlDataReader reader;
         public MonthDAL(){
            
                if (connection == null)
            {
                // connection = DBHelper.OpenConnection();
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Close();
                
            }
        }
        public Month GetDateByMonthID(int monthID)
        {
            query = @"select month_id, from_date, to_date from Month_ where month_id = '" + monthID + "';";

            reader = DBHelper.ExecQuery(query,connection);

            Month month = null;
            
                if (reader.Read())
                {
                    month = GetMonthInfo(reader);
                }
                connection.Close();
            
          
            
            return month;
        }

        private Month GetMonthInfo(MySqlDataReader reader)
        {
            Month month = new Month();
            month.FromDate = reader.GetString("from_date");
            month.ToDate = reader.GetString("to_date");

            return month;
        }
    }
}