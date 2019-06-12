using System;
using Xunit;
using Persistence;
using BL; 
namespace BL.test
{
    public class CustomerTest{
        CustomerBL cus= new CustomerBL();
        [Fact]
        public void GetCustomerbyIDTest1()
        {
           Assert.Null(cus.GetCustomerbyID(0));
        }
           [Fact]
        public void GetCustomerbyIDTest2()
        {
           Assert.NotNull(cus.GetCustomerbyID(1));
        }
           [Fact]
        public void InsertAndUpdateCustomerTest1()
        {
           Assert.True(cus.InsertCustomer("nguyen van a","ha noi","0123456789","0123456789"));
           Assert.True(cus.UpdateCustomer(1,"nguyen van nam","ha noi","0903198376","1234567890"));
        }
           [Fact]
        public void InsertAndUpdateCustomerTest2()
        {
           Assert.False(cus.InsertCustomer("nguyen van a","ha noi",null,null ));
           Assert.False(cus.UpdateCustomer(0,"nguyen van nam","ha noi",null,null));
        }
    }
}