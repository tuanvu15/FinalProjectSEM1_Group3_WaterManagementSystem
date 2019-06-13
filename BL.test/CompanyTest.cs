using System;
using Xunit;
using Persistence;
using BL; 
namespace BL.test
{
    public class CompanyTest{
         CompanyBL comBL= new CompanyBL();
         [Fact]
         public void GetinfoBycompanyIdTest1()
         {
          Assert.NotNull(comBL.GetinfoBycompanyId(1));
         }
         [Fact]
         public void GetinfoBycompanyIdTest2()
         {
          Assert.Null(comBL.GetinfoBycompanyId(0));
         }

    }
}