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
        public InvoiceDetail GetInvoiceByMonthAndCusID(int cusID, int month)
        {
            return invoiceDetail.GetInvoiceByMonthAndCusID(cusID, month);
        }
        public List<InvoiceDetail> GetInvoiceByCustomerID(int Id)
        {
            return invoiceDetail.GetInvoiceByCustomerId(Id);
        }
        public bool InsertInvoiceDetail(int customerID,int month_, int new_number, int old_number )
        {
            return invoiceDetail.InsertInvoiceDetail(customerID,month_, new_number, old_number);
        }
        
    }
}