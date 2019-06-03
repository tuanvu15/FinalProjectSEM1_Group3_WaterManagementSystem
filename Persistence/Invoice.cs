using System;

namespace Persistence
{
    public class Invoice
    {
        public int InvoiceId{get; set;}
        public string DateCreate {get; set;}
        public int UnitPrice {get; set;}

        public Invoice(){}

        public Invoice(int invoice_id, string date_create, int unit_price)
        {
            invoice_id = InvoiceId;
            date_create = DateCreate;
            unit_price = UnitPrice;
            
        }
    }
}