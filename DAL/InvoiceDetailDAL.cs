using System;
using Persistence;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class InvoiceDetailDAL
    {
        private MySqlDataReader reader;
        private string query;
        private MySqlConnection connection;
          public InvoiceDetailDAL()
        {
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
                // connection = DBHelper.Instance.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public InvoiceDetail GetInvoiceByMonthAndCusID(int cusID, int month)
        {
             if (connection == null)
            {
                connection = DBHelper.OpenConnection();
                // connection = DBHelper.Instance.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select Invoice_id, month_id, new_number, old_number from InvoiceDetail where customer_id = '" + cusID + "'and month_id = '" + month + "';";

            reader = DBHelper.ExecQuery(query,connection);

            InvoiceDetail invoice_detail = null;

            try
            {
                if (reader.Read())
                {
                    invoice_detail = GetInvoiceInfo(reader);
                }
                connection.Close();
            }
            catch (System.Exception)
            {

                return null;
            }

            return invoice_detail;
        }
        public List<InvoiceDetail> GetInvoiceByCustomerId(int Id)
        {
            query = @"select  Invoice_id, month_id, new_number, old_number from InvoiceDetail where customer_id = '" + Id + "';";

            reader = DBHelper.ExecQuery(query,connection);

            List<InvoiceDetail> inv = new List<InvoiceDetail>();
            while (reader.Read())
            {
                inv.Add(GetInvoiceInfo(reader));
            }
            connection.Close();

            return inv;
        }
        public InvoiceDetail GetInvoiceInfo(MySqlDataReader reader)
        {
            InvoiceDetail inv = new InvoiceDetail();
            inv.InvoiceId = reader.GetInt32("invoice_id");
            inv.Month = reader.GetInt32("month_id");
            inv.NewNUmber = reader.GetInt32("new_number");
            inv.OldNumber = reader.GetInt32("old_number");
            return inv;

        }
        public bool InsertInvoiceDetail(int cusID, int month, int newNB, int oldNB)
        {
            bool result = false;
                  if (connection == null)
            {
                connection = DBHelper.OpenConnection();
                // connection = DBHelper.Instance.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"insert into InvoiceDetail(customer_id,month_id,new_number,old_number)value('" + cusID + "','" + month + "','" + newNB + "','" + oldNB + "');";

            reader = DBHelper.ExecQuery(query,connection);

            InvoiceDetail invoiceDetail = null;
            try
            {
                if (reader.Read())
                {
                    invoiceDetail = GetInvoiceInfo(reader);
                }
                connection.Close();
                result = true;
            }
            catch (System.Exception)
            {

                result = false;
            }
            return result;
        }


    }
}