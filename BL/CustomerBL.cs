using System;
using Persistence;
using DAL;
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
        public Customer GetCustomer()
        {
            return customerDAL.GetCustomer();
        }
        public void InsertCustomer(int cusID, string cusName, string cusAddress, int Phone)
        {
             customerDAL.InsertCustomer(cusID,cusName,cusAddress,Phone);
        }

    }
}
