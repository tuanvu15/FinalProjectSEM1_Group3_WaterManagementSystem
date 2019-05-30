using System;
using Xunit;
using BL;

namespace BL.test
{
    public class CustomerTest
    {
        [Fact]
        public void GetCustomerbyIDTest1()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.NotNull(cusbl.GetCustomerbyID(1));
        }
        [Fact]
        public void GetCustomerbyIDTest2()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.Null(cusbl.GetCustomerbyID(0));
        }
        [Fact]
        public void GetCustomerTest1()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.NotNull(cusbl.GetCustomer());
        }
        [Fact]
        public void InsertCustomerTest1()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.NotNull(cusbl.InsertCustomer("nguyen", "ha", "0904108354"));//
        }
        [Fact]
        public void InsertCustomerTest2()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.Null(cusbl.InsertCustomer("12344", "5674567", "auqw"));
        }

        [Fact]
        public void UpdateCustomerTest1()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.NotNull(cusbl.UpdateCustomer(3, "men", "hai", "0904109652"));//
        }
        [Fact]
        public void UpdateCustomerTest2()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.Null(cusbl.UpdateCustomer(0, "men", "ha", "11111"));
        }
        [Fact]
        public void UpdateCustomerTest3()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.Null(cusbl.UpdateCustomer(1, "00000", "000000", "addgh"));//
        }
    }
}
