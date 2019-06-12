using System;
using Xunit;
using Persistence;
using BL;
namespace BL.test
{
    public class Meterlog
    {
        MeterLogsBL ml = new MeterLogsBL();
        [Fact]
        public void GetListMeterLogsByMonthTest()
        {
        Assert.NotNull(ml.GetListMeterLogsByMonth("6"));
        }
        
    }
}