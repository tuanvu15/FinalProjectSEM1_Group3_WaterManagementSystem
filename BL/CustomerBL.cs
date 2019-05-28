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
        public Customer InsertCustomer( string cusName, string cusAddress, string Phone)
        {
            return customerDAL.InsertCustomer(cusName,cusAddress,Phone);
            
        }
        public Customer UpdateCustomer(int id, string name, string address, string sdt)
        {
            return customerDAL.UpdateCustomer(id, name, address, sdt);
        }
        public string input(string str)
        {
            Regex regex = new Regex("[A-Za-z\\sỖÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪỬỮỰỲỴÝỶỸàáâãèéêìíòóôõùúăđĩũơưăạảấầẩẫậắằẳẵặẹẻẽềềểễệỉịọỏốồổỗộớờởỡợụủứừửữựỳỵỷỹ]");
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
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(str);
            while ((matchCollection.Count < str.Length) || (str == ""))
            {
                Console.WriteLine("Số điện thoại không được chứa chữ hoặc quá ngắn, mời nhập lại: ");
                str = Console.ReadLine();
                matchCollection = regex.Matches(str);
            }
            return str;
        }
        
    }
}
