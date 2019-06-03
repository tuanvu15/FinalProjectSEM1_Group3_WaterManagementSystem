using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DAL;
using Persistence;

namespace BL
{
    public class InvoiceBL
    {
        private InvoiceDAL invDAL;
        public InvoiceBL()
        {
            invDAL = new InvoiceDAL();
        }
        
        public void InsertInvoice(string date_create, int unit_price)
        {
             invDAL.InsertInvoice(date_create, unit_price);
        }
    }
}