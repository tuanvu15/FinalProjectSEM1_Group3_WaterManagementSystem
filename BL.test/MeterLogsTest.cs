using System;
using Xunit;
using Persistence;
using BL; 
namespace BL.test
{
    public class MeterlogsTest{
        MeterLogsBL mlBL= new MeterLogsBL();
        [Fact]
        public void GetListMeterLogsByMonthTest1()
        {
         Assert.NotNull(mlBL.GetListMeterLogsByMonth("6"));
        }
         
           [Fact]
        public void GetMeterLogsByMonthTest1()
        {
         Assert.Null(mlBL.GetMeterLogsByMonth("a1","6"));
        }
    }
}