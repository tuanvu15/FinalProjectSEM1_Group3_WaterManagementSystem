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

        public CustomerBL()
        {
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
            //    if (IsNumber(cusName))
            //    {
            //        return false;
            //    }
            //    if (IsNumber(cusAddress))
            //    {
            //        return false;
            //    }
            //    if (IsNumber(Phone))
            //    {
            //        return false;
            //    }

            return customerDAL.InsertCustomer(cusName, cusAddress, Phone);

        }
        public bool UpdateCustomer(int id, string name, string address, string sdt)
        {
            // if (!IsNumber(name) || name == null)
            //    {
            //        return false;
            //    }
            //    if (!IsNumber(address) || address == null)
            //    {
            //        return false;
            //    }
            //    if (!Is(sdt) || sdt == null)
            //    {
            //        return false;
            //    }

            return customerDAL.UpdateCustomer(id, name, address, sdt);
        }

     public bool IsNumber(string pText)
{
         string pattern = @"^[a-zA-Z0-9]{1,25}$";
         return Regex.IsMatch(pText, pattern);

            
}
  
        //  public bool Is(string pValue)
        // {
        //     Regex isValidInput = new Regex(@"^\d{10,11}$");
            
        //         if (!isValidInput.IsMatch(pValue)){
        //             return false;
        //         }
                    
            
        //     return true;
        // }
 
         public string input(string str)
        {
            Regex regex = new Regex("[A-Za-z]");
            MatchCollection matchCollection = regex.Matches(str);
            while ((matchCollection.Count < str.Length) || (str == ""))
            {
                Console.WriteLine(" Không được để trống, chứa số hoặc ký tự đặc biệt, Mời nhập lại: ");
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
                 Console.Write("nhập lại:");
                 str=Console.ReadLine();
            }
            return str;
        }

    }
}
