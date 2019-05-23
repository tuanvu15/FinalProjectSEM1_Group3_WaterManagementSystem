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
            return managersDAL.Login(userName, pass);
        }
        
    }
}