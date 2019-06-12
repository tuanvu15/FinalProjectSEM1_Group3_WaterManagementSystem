using System;
using System.Text.RegularExpressions;
using DAL;
using Persistence;
using System.Collections.Generic;
namespace BL
{
    public class MeterLogsBL
    {
          private MeterLogsDAL meterLogsDAL;
        public MeterLogsBL(){
            meterLogsDAL = new MeterLogsDAL();
        }
         
        public bool InsertMeterLogs (string mlID, string ml_status, string ml_month, int old_number, int new_number, string ml_time, string ml_type, string ml_place, string pay_status){
             
              return meterLogsDAL.InsertMeterLogs(mlID, ml_status, ml_month, old_number, new_number, ml_time, ml_type, ml_place, pay_status);
        }
        public MeterLogs GetMeterLogsByMonth(string mt_id, string month)
        {
            return meterLogsDAL.GetMeterLogsByMonth(mt_id, month );
        }
        public bool UpdatePayStatusMeterLogs(string id , string month_)
        {
            return meterLogsDAL.UpdatePayStatusMeterLogs(id, month_);
        }
        public List<MeterLogs> GetListMeterLogsByMonth(string id)
        {
            return  meterLogsDAL.GetListMeterLogsByMonth(id);
        }
        
    }
}