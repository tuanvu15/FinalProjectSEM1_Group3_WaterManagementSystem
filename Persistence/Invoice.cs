using System;

namespace Persistence
{
    public class Invoice
    {
        public int InvoiceId{get; set;}
        public DateTime DateCreate {get; set;}
        public int OldNumber{get; set;}
        public int NewNUmber{get; set;}

        public Invoice(){}

        public Invoice(int invoice_id, DateTime date_create, int old_number, int new_number)
        {
            invoice_id = InvoiceId;
            date_create = DateCreate;
            old_number = OldNumber;
            new_number = NewNUmber;
        }
    }
}