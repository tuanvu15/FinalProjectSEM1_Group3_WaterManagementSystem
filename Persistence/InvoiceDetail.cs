using System;

namespace Persistence
{
    public class InvoiceDetail
    {
        public int InvoiceId{get; set;}

        public int Month{get; set;}
        public int OldNumber{get; set;}
        public int NewNUmber{get; set;}

        public InvoiceDetail(){}

        public InvoiceDetail(int invoice_id,int month_, int old_number, int new_number)
        {
            invoice_id = InvoiceId;
            Month = month_;
            old_number = OldNumber;
            new_number = NewNUmber;

        }
    }
}