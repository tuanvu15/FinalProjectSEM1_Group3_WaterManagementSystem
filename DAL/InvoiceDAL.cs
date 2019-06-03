using System;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class InvoiceDAL
    {
        private string query;
        private MySqlConnection connection;
        

        public InvoiceDAL()
        {
            if(connection == null)
            {
                connection = DBHelper.Instance.OpenConnection();
            }
            //  if (connection.State == System.Data.ConnectionState.Closed)
            // {
            //     connection = DBHelper.Instance.OpenConnection();
                
            // }
        }
        private MySqlDataReader reader;
        public bool InsertInvoice(string dateCreate, int value)
        {
            bool result = false;
            query = @"insert into Invoice(date_create, unit_price)value('"+dateCreate+"','"+value+"');";
            
            reader = DBHelper.Instance.ExcQuery(query);

            Invoice invoice = new Invoice();
            if(reader.Read())
            {
                invoice = GetInvoiceInfo(reader);
            }
            try
            {
                if(reader.Read())
                {
                    invoice = GetInvoiceInfo(reader);
                }
                DBHelper.Instance.CloseConnection();
            }
            catch (System.Exception)
            {
                
                result = false;
            }
            return result;
        }

        private Invoice GetInvoiceInfo(MySqlDataReader reader)
        {
            Invoice inv = new Invoice();
            inv.DateCreate = reader.GetString("date_create");
            inv.UnitPrice = reader.GetInt32("unit_price");
            
            return inv;
        }
    }
}