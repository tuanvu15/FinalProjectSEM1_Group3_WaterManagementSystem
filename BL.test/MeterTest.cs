using System;
using Xunit;
using Persistence;
using BL; 
namespace BL.test
{
    public class MeterTest{
        MeterBL mBL = new MeterBL();
        [Fact]
        public void GetMeterbyCusIDTest1()
        {
         Assert.NotNull(mBL.GetMeterbyCusID(1));
        }
             [Fact]
        public void GetMeterbyCusIDTest2()
        {
         Assert.Null(mBL.GetMeterbyCusID(0));
        }
             [Fact]
        public void GetMeterbyIDTest1()
        {
        Assert.NotNull(mBL.GetMeterbyID("a1"));
        }
          [Fact]
        public void GetMeterbyIDTest2()
        {
        Assert.NotNull(mBL.GetMeterbyID("0"));
        }
           [Fact]
           public void InserMeterTest1()
           {
           Assert.True(mBL.InsertMeter("a20",1,"dang hoat dong",0,0,"sinh hoat","192-minh khai-ha noi"));
           }
            [Fact]
           public void InserMeterTest2()
           {
           Assert.False(mBL.InsertMeter(null,1,"dang hoat dong",0,0,"sinh hoat","192-minh khai-ha noi"));
           }
           [Fact]
           public void UpdateMeterTest1()
           {
          Assert.True(mBL.UpdateMeter(2,"a2","dang hoat dong",0,0,"sinh hoat","123-minh khai ha noi"));
           }
           [Fact]
           public void UpdateMeterTest2()
           {
          Assert.True(mBL.UpdateMeter(2,"a","dang hoat dong",0,0,"sinh hoat","123-minh khai ha noi"));
           }
    }
}