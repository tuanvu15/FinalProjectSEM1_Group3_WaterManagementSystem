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

        public InvoiceDetail GetInvoiceByMonth(int cusID, int month)
        {
            query = @"select Invoice_id, month_id, new_number, old_number from InvoiceDetail where customer_id = '" + cusID + "'and month_id = '" + month + "';";

            reader = DBHelper.Instance.ExcQuery(query);

            InvoiceDetail invoice_detail = null;

            try
            {
                if (reader.Read())
                {
                    invoice_detail = GetInvoiceInfo(reader);
                }
                DBHelper.Instance.CloseConnection();
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

            reader = DBHelper.Instance.ExcQuery(query);

            List<InvoiceDetail> inv = new List<InvoiceDetail>();
            while (reader.Read())
            {
                inv.Add(GetInvoiceInfo(reader));
            }
            DBHelper.Instance.CloseConnection();

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
            query = @"insert into InvoiceDetail(customer_id,month_id,new_number,old_number)value('" + cusID + "','" + month + "','" + newNB + "','" + oldNB + "');";

            reader = DBHelper.Instance.ExcQuery(query);

            InvoiceDetail invoiceDetail = null;
            try
            {
                if (reader.Read())
                {
                    invoiceDetail = GetInvoiceInfo(reader);
                }
                DBHelper.Instance.CloseConnection();
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