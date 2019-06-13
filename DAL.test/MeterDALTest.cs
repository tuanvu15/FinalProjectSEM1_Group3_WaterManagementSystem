using System;
using Xunit;
using DAL;
using Persistence;
namespace DAL.test
{
    public class MeterDALTest
    {
       MeterDAL mDAL = new MeterDAL();
       [Fact]
       public void GetMeterbyCusIDTest1()
       {
         Assert.NotNull(mDAL.GetMeterbyCusID(1));
       }
        [Fact]
       public void GetMeterbyIDTest1()
       {
         Assert.NotNull(mDAL.GetMeterbyID("a5"));
       }
        [Fact]
           public void InserMeterTest1()
           {
           Assert.True(mDAL.InsertMeter("a24",1,"dang hoat dong",0,0,"sinh hoat","192-minh khai-ha noi"));
           }
            [Fact]
           public void InserMeterTest2()
           {
           Assert.False(mDAL.InsertMeter(null,12,"dang hoat dong",0,0,"sinh hoat","192-minh khai-ha noi"));
           }
           [Fact]
           public void UpdateMeterTest1()
           {
          Assert.True(mDAL.UpdateMeter(2,"a2","dang hoat dong",0,0,"sinh hoat","123-minh khai ha noi"));
           }
           [Fact]
           public void UpdateMeterTest2()
           {
          Assert.True(mDAL.UpdateMeter(2,"a","dang hoat dong",0,0,"sinh hoat","123-minh khai ha noi"));
           }
       
    }
}
