using System;

namespace Persistence
{
    public class MeterLogs
    {
        public string MeterID{get; set;}
        public int MeterLogID{get;set;}
        public string MeterLogsStatus{get; set;}
        public string MeterLogsMonth{get; set;}
        public int OldNumber{get;set;}
        public int NewNumber{get;set;}
        public DateTime MeterLogsTime{get; set;}
        public string MeterType{get;set;}
        public string MeterPlace{get;set;}
        public string PayStatus{get; set;}
        public MeterLogs(){}
        public MeterLogs(string meterId,int meter_logID,string mL_status ,string mL_month, int _oldnumber,int _newnumber,DateTime mL_time,string mL_type,string _place, string pay)
        {
            meterId = MeterID;
            meter_logID = MeterLogID;
            mL_status = MeterLogsStatus;
            mL_month = MeterLogsMonth;
            _oldnumber = OldNumber;
            _newnumber=NewNumber;
            mL_time = MeterLogsTime;
            mL_type = MeterType;
            _place = MeterPlace;
            pay = PayStatus;
        }

    }
}