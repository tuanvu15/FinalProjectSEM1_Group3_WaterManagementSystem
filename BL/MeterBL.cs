using System;
using System.Text.RegularExpressions;
using DAL;
using Persistence;
using System.Collections.Generic;
namespace BL
{
    public class MeterBL
    {
        private MeterDAL meterDAL;
        public MeterBL()
        {
            meterDAL = new MeterDAL();
        }
        // public Meter GetMeterbyID(int metID)
        // {

        //     return meterDAL.GetMeterbyID(metID);
        // }
        public List<Meter> GetMeter()
        {
            return meterDAL.GetMeter();
        }
        // public Meter GetMeterbyID(int metID)
        // {

        //     return meterDAL.GetMeterbyID(metID);
        // }
        public bool InsertMeter(string meter_id,int cusID, string meterStatus, int oldNumber, int newNumber, string meterType, string meterPlace)
        {

            return meterDAL.InsertMeter(meter_id,cusID, meterStatus, oldNumber, newNumber, meterType, meterPlace);
        }
        public bool UpdateMeter(int cusID,string id, string meterStatus, int oldNumber, int newNumber, string meterType, string meterPlace)
        {
            return meterDAL.UpdateMeter(cusID,id, meterStatus, oldNumber, newNumber, meterType, meterPlace);
        }
        public Meter GetMeterbyCusID(int id)
        {
            return meterDAL.GetMeterbyCusID(id);
        }
        public Meter GetMeterbyID(string id)
        {
            return meterDAL.GetMeterbyID(id);
        }


    }
}