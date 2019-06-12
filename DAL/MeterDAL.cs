using System;
using Persistence;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
namespace DAL
{
    public class MeterDAL
    {
        private string query;
        //  DBHelper db = DBHelper.GetInstance();
        private MySqlConnection connection;
        private MySqlDataReader reader;
        public MeterDAL()
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
        public List<Meter> GetMeter()
        {
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            //   query = @"select meter_status,old_number,new_number,meter_place from Meter;";
            query = @"select * from Meter";
            reader = DBHelper.ExecQuery(query, connection);
            List<Meter> met = new List<Meter>();
            while (reader.Read())
            {
                met.Add(GetMeterInfo(reader));
            }
            connection.Close();
            return met;
        }
        public Meter GetMeterbyCusID(int ID)
        {
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select meter_id,meter_status,old_number,new_number,meter_type,meter_place from Meter where customer_id = " + ID + ";";
            Meter met = null;
            reader = DBHelper.ExecQuery(query, connection);
            if (reader.Read())
            {
                met = GetMeterInfo(reader);
            }
            connection.Close();
            return met;

        }
        public Meter GetMeterbyID(string metID)
        {
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select meter_id,meter_status,old_number,new_number,meter_type,meter_place from Meter where meter_id = '" + metID + "';";
            Meter met = new Meter();
            reader = DBHelper.ExecQuery(query, connection);
            if (reader.Read())
            {
                met = GetMeterInfo(reader);
            }
            connection.Close();
            return met;

        }
        public bool InsertMeter(string meter_id, int cusID, string meterStatus, int oldNumber, int newNumber, string meterType, string meterPlace)
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
           

            query = @"insert into Meter(meter_id,customer_id,meter_status,old_number,new_number,meter_type,meter_place) value ('" +meter_id+ "','" + cusID + "','" + meterStatus + "'," + oldNumber + "," + newNumber + ",'" + meterType + "','" + meterPlace + "');";

            reader = DBHelper.ExecQuery(query, connection);
            Meter meter = null;
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                if (reader.Read())
                {
                    meter = GetMeterInfo(reader);

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
        public bool UpdateMeter(int cusID ,string id, string meterStatus, int oldNumber, int newNumber, string meterType, string meterPlace)
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
            query = @"update Meter set meter_id ='"+ id +"',meter_status ='" + meterStatus + "', old_number =" + oldNumber + ",new_number =" + newNumber +
            ",meter_type ='" + meterType + "',meter_place ='" + meterPlace + "' where customer_id = '" + cusID + "';";

            reader = DBHelper.ExecQuery(query, connection);

            Meter met = null;
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);

                if (reader.Read())
                {
                    met = GetMeterInfo(reader);
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
        public List<Meter> GetListMeter()
        {
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select * from Meter;";
            reader = DBHelper.ExecQuery(query, connection);
            List<Meter> meter = new List<Meter>();
            while (reader.Read())
            {
                meter.Add(GetMeterInfo(reader));
            }
            connection.Close();
            return meter;
        }
        public Meter GetMeterInfo(MySqlDataReader reader)
        {
            Meter meters = new Meter();

            meters.MeterID = reader.GetString("meter_id");
            meters.MeterStatus = reader.GetString("meter_status");
            meters.OldNumber = reader.GetInt32("old_number");
            meters.NewNumber = reader.GetInt32("new_number");
            meters.MeterType = reader.GetString("meter_type");
            meters.MeterPlace = reader.GetString("meter_place");

            return meters;
        }

    }
}

