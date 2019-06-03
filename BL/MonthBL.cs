using System;
using System.Text.RegularExpressions;
using DAL;
using Persistence;

namespace BL
{
    public class MonthBL
    {
        private MonthDAL month;

        public MonthBL()
        {
            month = new MonthDAL();
        }
        public Month GetDateByMonthId(int id)
        {
            return month.GetDateByMonthID(id);
        }
        
    }
}