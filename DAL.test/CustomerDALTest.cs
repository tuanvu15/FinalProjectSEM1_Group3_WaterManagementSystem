using System;
using Xunit;
using Persistence;
using DAL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace DAL.test
{
    
    public class CustomerDALTest
    {
        CustomerDAL cusdl = new CustomerDAL();
       
        [Fact]
        public void GetCustomerbyIDTest1()
        {
           
           Assert.NotNull(cusdl.GetCustomerbyID(1));
        }
         [Fact]
        public void GetCustomerbyIDTest2()
        {
         
           Assert.Null(cusdl.GetCustomerbyID(0));
        }
        [Fact]
        public void GetCustomerTest()
        {
       
        Assert.NotNull(cusdl.GetCustomer());
        }
      
        
        [Fact]
        public void InsertCustomerTest1()
        {
            string name ="pham van A";
            string address = "ha noi";
            string phones = "0123456789";
            string cmnd = "010200001527";
            bool cus =cusdl.InsertCustomer(name,address,phones,cmnd);
            Assert.True(cus);
        }
           [Fact]
        public void InsertCustomerTest2()
        {
          string name =null;
            string address = null;
            string phones = null;
            string cmnd = null;
            bool cus =cusdl.InsertCustomer(name,address,phones,cmnd);
            Assert.False(cus);
        }
        
        [Fact]
        public void UpdateCustomerTest1()
        {
         int id =1;
             string name ="pham van a";
            string address = "ha noi";
            string phones = "0123456789";
            string cmnd = "010200001527";
            bool cus =cusdl.UpdateCustomer(id,name,address,phones,cmnd);
            Assert.True(cus);
        }
         [Fact]
        public void UpdateCustomerTest2()
        {
            int id =1;
             string name =null;
            string address = null;
            string phones = null;
            string cmnd = null;
            bool cus =cusdl.UpdateCustomer(id,name,address,phones,cmnd);
            Assert.False(cus);
        }
        //  [Fact]
        // public void UpdateCustomerTest3()
        // {
        //    int id = 0;
        //      string name =null;
        //     string address = null;
        //     string phones = null;
        //     bool cus =cusdl.UpdateCustomer(id,name,address,phones);
        //     Assert.False(cus);
        // }
        
    }
}