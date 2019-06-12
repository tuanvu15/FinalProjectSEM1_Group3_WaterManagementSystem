using System;
using Persistence;
using DAL;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BL
{
    public class CustomerBL
    {
        private CustomerDAL customerDAL;
        public CustomerBL(){
            customerDAL = new CustomerDAL();
        }
       
        public Customer GetCustomerbyID(int cusid)
        {

            return customerDAL.GetCustomerbyID(cusid);
        }
        public List<Customer> GetCustomer()
        {
            return customerDAL.GetCustomer();
        }
        public bool InsertCustomer(string cusName, string cusAddress, string Phone,string cmnd)

        {
            if (!isnumber(Phone)||!checkstring(cusName)||!checkstring(cusAddress)||!isnumber(cmnd))
            {
                return false;
            }
           

            return customerDAL.InsertCustomer(cusName, cusAddress, Phone,cmnd);

        }
        public bool UpdateCustomer(int id, string name, string address, string sdt,string cmnd)
        {
              if (!isnumber(sdt)||!checkstring(name)||!checkstring(address)||!isnumber(cmnd))
            {
                return false;
            }
              if (id <= 0)
              {
                  return false;
              }
            return customerDAL.UpdateCustomer(id, name, address, sdt,cmnd);
        }

       
        public bool checkstring(string str)
        {
            str = str ?? string.Empty;
            string strRegex = @"[a-zA-Z]";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(str))
            {
                return (true);
            }
            else
                return (false);
        }


        public bool isnumber(string str)
        {
            str = str ?? string.Empty;
            string strRegex = @"[0-9]";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(str))
            {
                return (true);
            }
            else
                return (false);
        }
        public string input(string str)
        {
            string strRegex =@"[a-zA-Z]";
            Regex regex = new Regex(strRegex);
            
            MatchCollection matchCollection = regex.Matches(str);
            while ((!regex.IsMatch(str)) || (str == ""))
            {
                Console.Write(" Không được để trống, chứa số hoặc ký tự đặc biệt, Mời nhập lại: ");
                str = Console.ReadLine();
                matchCollection = regex.Matches(str);
                
            }
            return str;
        }
     
        public string Validate(string str)
        {

            Regex isValidInput = new Regex(@"^\d{10,11}$");
            // string strPhone = Console.ReadLine();
            while (!isValidInput.IsMatch(str))
            {
                Console.WriteLine("sai định dạng(0123456789)");
                Console.Write("\tnhập lại:");
                str = Console.ReadLine();
            }
            return str;
        }
         public int checkid(){
            int chon;
             while (true)
            {
                try
                {
                    chon = Int32.Parse(Console.ReadLine());
                }
                catch (System.Exception)
                {
                    Console.Write("Nhập không hợp lệ!!!Nhập lại:");
                    continue;
                }
               

            return chon;
        }

    }
    
}
}
