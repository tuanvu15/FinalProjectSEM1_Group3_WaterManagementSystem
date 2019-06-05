using System;
using Xunit;
using BL;
using Persistence;
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
            Assert.True(cusbl.InsertCustomer("nam", "ha noi", "0904108354"));
        }
        [Fact]
        public void InsertCustomerTest2()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.False(cusbl.InsertCustomer("12344", "5674567", "auqw"));//
        }
           [Fact]
        public void InsertCustomerTest3()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.False(cusbl.InsertCustomer(null, null, null));
        }
        [Fact]
        public void UpdateCustomerTest1()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.True(cusbl.UpdateCustomer(4,"men", "hai", "0904109652"));
        }
        [Fact]
        public void UpdateCustomerTest2()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.False(cusbl.UpdateCustomer(0,"men", "ha", "11111"));//
        }
        [Fact]
        public void UpdateCustomerTest3()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.False(cusbl.UpdateCustomer(1, "0123", "0123", "xxxxxx"));
        }
        [Fact]
        public void UpdateCustomerTest4()
        {
            CustomerBL cusbl = new CustomerBL();
            Assert.False(cusbl.UpdateCustomer(1, null, null, null));
        }
    }
}
