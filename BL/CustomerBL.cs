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
       
        public Customer GetCustomerbyID(int a)
        {

            return customerDAL.GetCustomerbyID(a);
        }
        public List<Customer> GetCustomer()
        {
            return customerDAL.GetCustomer();
        }
        public bool InsertCustomer(string cusName, string cusAddress, string Phone)

        {
            if (!isnum(Phone))
            {
                return false;
            }
            if (!isch(cusName))
            {
                return false;
            }
            if (!isch(cusAddress))
            {
                return false;
            }

            return customerDAL.InsertCustomer(cusName, cusAddress, Phone);

        }
        public bool UpdateCustomer(int id, string name, string address, string sdt)
        {
              if (!isnum(sdt))
            {
                return false;
            }
            if (!isch(name))
            {
                return false;
            }
            if (!isch(address))
            {
                return false;
            }
           
            return customerDAL.UpdateCustomer(id, name, address, sdt);
        }

        public bool isch(string str)
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


        public bool isnum(string str)
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
                Console.WriteLine(" Không được để trống, chứa số hoặc ký tự đặc biệt, Mời nhập lại: ");
                str = Console.ReadLine();
                matchCollection = regex.Matches(str);
                
            }
            return str;
        }
        // public string isadd(string str){
        //     string strRegex = "^[a-zA-Z0-9]*$";
        //     Regex regex = new Regex(strRegex);
        //     MatchCollection matchCollection = regex.Matches(str);
        //     while ((!regex.IsMatch(str)) || (str == ""))
        //     {
        //         Console.WriteLine(" Không được để trống, chứa số hoặc ký tự đặc biệt, Mời nhập lại: ");
        //         str = Console.ReadLine();
        //         matchCollection = regex.Matches(str);
        //     }
        //     return str;
        // }
        public string Validate(string str)
        {

            Regex isValidInput = new Regex(@"^\d{10,11}$");
            // string strPhone = Console.ReadLine();
            while (!isValidInput.IsMatch(str))
            {
                Console.WriteLine("sai định dạng(0123456789)");
                Console.Write("nhập lại:");
                str = Console.ReadLine();
            }
            return str;
        }

    }
}
