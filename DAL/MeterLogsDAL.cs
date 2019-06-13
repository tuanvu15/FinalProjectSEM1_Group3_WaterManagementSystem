using System;
using Persistence;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
namespace DAL
{
    public class MeterLogsDAL
    {
        private string query;
        //  DBHelper db = DBHelper.GetInstance();
        private MySqlConnection connection;
        private MySqlDataReader reader;
        public MeterLogsDAL()
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
        public bool UpdatePayStatusMeterLogs(string id, string month)
        {
            bool result = true;

              if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"update Meter_logs set Pay_status = 'Đã thanh toán' where meter_id = '" + id +"' and ml_month = '"+ month+"';";

            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                
                if (command.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                // DBHelper.CloseConnection();
                connection.Close();
                return true;
            }
            catch (System.Exception)
            {
                result = false;

            }

            return result;

        }
        public List<MeterLogs> GetListMeterLogsByMonth(string month_)
        {
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select meter_id,ml_id ,ml_status,ml_month ,ml_oldnumber,ml_newnumber ,ml_time, ml_type, ml_place, pay_status from Meter_Logs where ml_month = '" + month_+ "' ;";
            reader = DBHelper.ExecQuery(query, connection);
            List<MeterLogs> ListMeterLogs = new List<MeterLogs>();
            while (reader.Read())
            {
                ListMeterLogs.Add(GetMeterLogsInfo(reader));
            }
            connection.Close();
            return ListMeterLogs;

        }

        public bool InsertMeterLogs(string meterID, string ml_status, string ml_month, int old_number, int new_number, string ml_time, string ml_type, string ml_place, string pay_status)
        {
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            bool result = true;

            query = @"insert into Meter_logs(meter_id ,ml_status,ml_month ,ml_oldnumber,ml_newnumber ,ml_time, ml_type, ml_place, pay_status) 
            value ('" + meterID + "','" + ml_status + "','" + ml_month + "'," + old_number + "," + new_number + ",'" + ml_time + "','" + ml_type + "','"+ml_place+"','" + pay_status + "');";
           
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                if (command.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                connection.Close();
                return true;
            }
            catch (System.Exception)
            {
                result = false;

            }
            return result;
        }
        public MeterLogs GetMeterLogsByMonth(string ID, string month)
        {
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select meter_id,ml_id ,ml_status,ml_month ,ml_oldnumber,ml_newnumber ,ml_time, ml_type, ml_place, pay_status
            from Meter_logs where Meter_id = '" + ID + "' and ml_month = '" + month + "';";
            MeterLogs met = null;
            reader = DBHelper.ExecQuery(query, connection);
            if (reader.Read())
            {
                met = GetMeterLogsInfo(reader);
            }
            connection.Close();
            return met;

        }
        public MeterLogs GetMeterLogsInfo(MySqlDataReader reader)
        {
            MeterLogs meters = new MeterLogs();

            meters.MeterID =reader.GetString("meter_id");
            meters.MeterLogID = reader.GetInt32("ml_id");
            meters.MeterLogsStatus = reader.GetString("ml_status");
            meters.MeterLogsMonth = reader.GetString("ml_month");
            meters.OldNumber = reader.GetInt32("ml_oldnumber");
            meters.NewNumber = reader.GetInt32("ml_newnumber");
            meters.MeterLogsTime = reader.GetDateTime("ml_time");
            meters.MeterType = reader.GetString("ml_type");
            meters.MeterPlace = reader.GetString("ml_place");
            meters.PayStatus = reader.GetString("pay_status");

            return meters;
        }

    }
}

