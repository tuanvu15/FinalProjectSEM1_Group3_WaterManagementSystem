using System;
using Xunit;
using BL;
namespace BL.test
{
    
    public class Testlogin
    {
        
        [Fact]
        public void Test1()
        {
            
         ManagersBL magBl= new ManagersBL();
         Assert.NotNull(magBl.Login("manager01@gmail.com","12345678"));
        } 
        [Fact]
        public void test2()
        {
        ManagersBL magBl = new ManagersBL();
        Assert.Null(magBl.Login("customet@gmail.com","1234"));
        }
        
    }
}
