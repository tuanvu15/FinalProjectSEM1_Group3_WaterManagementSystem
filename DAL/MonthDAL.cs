using System;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class MonthDAL
    {
        private string query;

        private MySqlDataReader reader;
        public Month GetDateByMonthID(int monthID)
        {
            query = @"select month_id, from_date, to_date from Month_ where month_id = '" + monthID + "';";

            reader = DBHelper.Instance.ExcQuery(query);

            Month month = null;
            try
            {
                if (reader.Read())
                {
                    month = GetMonthInfo(reader);
                }
                DBHelper.Instance.CloseConnection();
            }
            catch (System.Exception)
            {

                return null;
            }
            
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