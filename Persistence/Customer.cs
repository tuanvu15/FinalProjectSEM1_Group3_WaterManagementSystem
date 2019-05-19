using System;

namespace Persistence
{
    public class Customer
    {
        public int CustomerId {get; set;}
        public string CustomerName {get; set;}
        public string CustomerAddress {get; set;}
        public int PhoneNumber{get; set;}

        public Customer(){}
        public Customer(int cusId, string cusName, string cusAddress, int phone)
        {
            cusId = CustomerId;
            cusName = CustomerName;
            cusAddress = CustomerAddress;
            phone = PhoneNumber;
        }
    }
    
}

