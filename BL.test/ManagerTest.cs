using System;
using Xunit;
using BL;
using Persistence;
namespace BL.test
{

    public class ManagerTest
    {

        [Fact]
        public void LoginTest1()
        {
            ManagersBL magBl = new ManagersBL();
            Assert.NotNull(magBl.Login("manager01@gmail.com", "12345678"));
        }
        [Fact]
        public void LoginTest2()
        {
            ManagersBL magBl = new ManagersBL();
            Assert.Null(magBl.Login("customer", "1234"));
        }
        [Fact]
        public void LoginTest3()
        {
            ManagersBL magBl = new ManagersBL();
            Assert.Null(magBl.Login("!@#", "###"));
        }
        [Fact]
        public void LoginTest4()
        {
            ManagersBL magBl = new ManagersBL();
            Assert.Null(magBl.Login(null, null));
        }
       
    }
}
