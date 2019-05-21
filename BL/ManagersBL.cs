using System;
using DAL;
using Persistence;
using System.Text;
using System.Text.RegularExpressions;

namespace BL
{
    public class ManagersBL
    {
        private ManagersDAL managersDAL;

        public ManagersBL()
        {
            
            managersDAL = new ManagersDAL();
        }
        public Managers Login(string email, string pass)
        {
            if((email == null) || (pass == null))
            {
                return null;
            }
            
            return managersDAL.Login(email, pass);
        }
    
    }
    
}