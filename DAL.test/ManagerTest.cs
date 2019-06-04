using System;
using Xunit;
using DAL;
using Persistence;
namespace DAL.test
{
    public class ManagerTest
    {
         private ManagersDAL manager = new ManagersDAL();
        [Theory]
        [InlineData("manager01@gmail.com", "12345678")]
        
        public void LoginTest1(string username, string password)
        {
            // User user = userDAL.Login(username, password);
                 
            Assert.NotNull(manager.Login(username,password));
           
        }

        [Theory]
        [InlineData("customer_01", "123456789")]
        [InlineData("'?^%'", "'.:=='")]
        [InlineData("'?^%'",null)]
        [InlineData(null, "'.:=='")]
        public void LoginTest3(string username, string password)
        {
            Assert.Null(manager.Login(username,password));
        }
    }
}
