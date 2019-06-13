using System;
using Xunit;
using DAL;
using MySql.Data.MySqlClient;

namespace DAL.test
{
    public class DBHelperTest
    {
        [Fact]
        public void OpenConnectionTest()
        {   
            Assert.NotNull(DBHelper.OpenConnection());
        }
        
     
    }
}
