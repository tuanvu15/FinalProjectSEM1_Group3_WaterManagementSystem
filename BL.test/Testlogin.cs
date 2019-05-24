using System;
using Xunit;
using BL;
namespace BL.test
{
    
    public class Testlogin
    {
        
        [Fact]
        public void LoginTest1()
        {
         ManagersBL magBl= new ManagersBL();
         Assert.NotNull(magBl.Login("manager01@gmail.com","12345678"));
        } 
        [Fact]
        public void LoginTest2()
        {
        ManagersBL magBl = new ManagersBL();
        Assert.Null(magBl.Login("customet","1234"));
        }
        [Fact]
        public void LoginTest3()
        {
         ManagersBL magBl = new ManagersBL();
         Assert.Null(magBl.Login("!@#","###"));
        }
        
    }
}
