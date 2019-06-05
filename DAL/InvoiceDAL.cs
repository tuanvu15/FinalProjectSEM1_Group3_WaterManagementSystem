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
                connection = DBHelper.OpenConnection();
            }
             if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                
            }
        }
        private MySqlDataReader reader;
        public bool InsertInvoice(string dateCreate, int value)
        {
            bool result = false;
            query = @"insert into Invoice(date_create, unit_price)value('"+dateCreate+"','"+value+"');";
            
            reader = DBHelper.ExecQuery(query,connection);

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
                connection.Close();
            }
            catch (System.Exception)
            {
                
                result = false;
            }
            return result;
        }
        public Invoice GetInvoiceByID(int ID)
        {

            query = @"select Invoice_id, date_create, unit_price from Invoice where invoice_id = '"+ID+"';";
            Invoice invoice = null;
            reader = DBHelper.ExecQuery(query, connection);
            if (reader.Read())
            {
                invoice = GetInvoiceInfo(reader);
            }
            connection.Close();
            return invoice;
        }

        private Invoice GetInvoiceInfo(MySqlDataReader reader)
        {
            Invoice inv = new Invoice();
            inv.InvoiceId = reader.GetInt32("invoice_id");
            inv.DateCreate = reader.GetDateTime("date_create");
            inv.UnitPrice = reader.GetInt32("unit_price");
            
            return inv;
        }
    }
}