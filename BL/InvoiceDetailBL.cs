using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DAL;
using Persistence;

namespace BL
{
    public class InvoiceDetailBL
    {
        private InvoiceDetailDAL invoiceDetail;

        public InvoiceDetailBL()
        {
            invoiceDetail = new InvoiceDetailDAL();
        }
        public InvoiceDetail GetInvoiceByMonth(int cusID, int month)
        {
            return invoiceDetail.GetInvoiceByMonth(cusID, month);
        }
        public List<InvoiceDetail> GetInvoiceByCustomerID(int Id)
        {
            return invoiceDetail.GetInvoiceByCustomerId(Id);
        }
        public void InsertInvoiceDetail(int customerID,int month_, int new_number, int old_number )
        {
            invoiceDetail.InsertInvoiceDetail(customerID,month_, new_number, old_number);
        }
        
    }
}