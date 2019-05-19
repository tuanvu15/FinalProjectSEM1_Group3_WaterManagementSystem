using System;
using Persistence;
using DAL;
using System.Collections.Generic;

namespace BL
{
    public class CustomerBL
    {
        private CustomerDAL customerDAL;
        public CustomerBL()
        {
            customerDAL = new CustomerDAL();
        }
        public Customer GetCustomerbyID(int a)
        {
            return customerDAL.GetCustomerbyID(a);
        }
        public List<Customer> GetCustomer()
        {
            return customerDAL.GetCustomer();
        }
        public void InsertCustomer(int cusID, string cusName, string cusAddress, int Phone)
        {
             customerDAL.InsertCustomer(cusID,cusName,cusAddress,Phone);
        }
        public void UpdateCustomer(int id, string name, string address, int sdt)
        {
            customerDAL.UpdateCustomer(id, name, address, sdt);
        }
        
    }
}
