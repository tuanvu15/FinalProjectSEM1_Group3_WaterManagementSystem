using System;

namespace Persistence
{
    public class Month
    {
        public int MonthID{get; set;}
        public string FromDate{get; set;}
        public string ToDate{get; set;}

        public Month(){}
        public Month(int id ,string from_date, string to_date)
        {
            id = MonthID;
            from_date = FromDate;
            to_date = ToDate;
        }

    }
}