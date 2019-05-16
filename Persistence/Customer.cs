using System;

namespace Persistence
{
    public class Customer
    {
        public int CustomerId {get; set;}
        public string CustomerName {get; set;}
        public string CustomerAddress {get; set;}
        public string PhoneNumber{get; set;}

        public Customer(){}
        public Customer(int cusId, string cusName, string cusAddress, string phoneNumber)
        {
            cusId = CustomerId;
            cusName = CustomerName;
            cusAddress = CustomerAddress;
            phoneNumber = PhoneNumber;
        }
    }
    
}

