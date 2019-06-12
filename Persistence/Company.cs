using System;

namespace Persistence
{
    public class Company
    {
       
        public string CompanyName{get; set;}
        public string Represent{get; set;}
        public string Title{get; set;}
        public string Tax{get; set;}

        public string AccountNumber{get; set;}
        public string HeadQuarters{get;set;}
        public string Phone{get;set;}
        public Company(){}
        public Company(string _name, string _represent,string _title,string _tax,string _accnumber,string _headquarters,string _phone)
        {
         
          _name = CompanyName;
          _represent = Represent;
          _title = Title;
          _tax = Tax;
          _accnumber = AccountNumber;
          _headquarters = HeadQuarters;
          _phone = Phone;
        }

    }
}