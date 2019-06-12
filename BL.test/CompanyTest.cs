using System;
using Xunit;
using Persistence;
using BL; 
using System.Collections.Generic;
namespace BL.test
{
    public class CompanyTest{
       
       [Fact]
       public void GetinfoBycompanyIdTest()
       {
           CompanyBL com = new CompanyBL();
           Assert.NotNull(com.GetinfoBycompanyId(1));
           Assert.Null(com.GetinfoBycompanyId(0));

       }
      
    }
}