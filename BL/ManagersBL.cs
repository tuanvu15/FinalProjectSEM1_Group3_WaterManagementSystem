using System;
using System.Text.RegularExpressions;
using DAL;
using Persistence;

namespace BL
{
    public class ManagersBL
    {
        private ManagersDAL managersDAL;
       
        public ManagersBL()
        {
            managersDAL = new ManagersDAL();
        }
        public Managers Login(string userName, string pass)
        {
            if (userName == null || pass == null)
            {
                return null;
            }
            if (!isEmail(userName))
            {
                Console.WriteLine("email ko hợp lệ (email@gmail.com)");
            }
            if (!ispass(pass))
            {
                Console.WriteLine("passworld không hợp lệ");
            }
            
           
            return managersDAL.Login(userName, pass);
        }
        public bool ispass(string inputpass){
          inputpass = inputpass ?? string.Empty;
          string strRegex = @"[a-zA-Z0-9_]";  
          Regex re = new Regex(strRegex);
          if (re.IsMatch(inputpass))
          {
              return (true);
          }        
          else
            return (false);
        }
        public  bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
    }
}


