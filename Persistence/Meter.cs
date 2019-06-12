using System;

namespace Persistence
{
    public class Meter
    {
        public string MeterID{get;set;}
        public string MeterStatus{get; set;}
        public int OldNumber{get;set;}
        public int NewNumber{get;set;}
        public string MeterType{get;set;}
        public string MeterPlace{get;set;}
        public Meter(){}
        public Meter(string _id ,string _status, int _oldnumber,int _newnumber,string _type,string _place)
        {
           _id = MeterID;
           _status= MeterStatus;
           _oldnumber = OldNumber;
           _newnumber=NewNumber;
           _type = MeterType;
           _place = MeterPlace;
        }

    }
}