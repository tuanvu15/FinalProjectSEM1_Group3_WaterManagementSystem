using System;
using Xunit;
using Persistence;
using BL;
namespace BL.test
{
    public class MeterTest
    {
        MeterBL met = new MeterBL();
        [Fact]
        public void GetMeterbyCusIDTest1()
        {
         Assert.NotNull(met.GetMeterbyCusID(1));
         Assert.Null(met.GetMeterbyCusID(0));
        }
        [Fact]
        public void InsertAndUpdateMeterTest1()
        {
        Assert.True(met.InsertMeter("a19",8,"dang hoat dong",0,0,"sinh hoat","ha noi"));
        Assert.True(met.UpdateMeter(1,"a1","dang hoat dong",0,0,"sinh hoat","ha noi"));
        }
         
        
        [Fact]
        public void GetMeterbyIDTest1()
        {
        Assert.NotNull(met.GetMeterbyID("a4"));
        
        }
    }
}