using System;
using Xunit;
using DAL;
using Persistence;
namespace DAL.test
{
    public class CompanyTest
    {
     public void GetinfoBycompanyIdTest()
     {
         CompanyDAL com = new CompanyDAL();
         Assert.NotNull(com.GetinfoBycompanyID(1));
     }
    }
}
