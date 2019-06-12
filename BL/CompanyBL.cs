using System;
using System.Text.RegularExpressions;
using DAL;
using Persistence;

namespace BL
{
    public class CompanyBL
    {
        private CompanyDAL company;

        public CompanyBL()
        {
            company = new CompanyDAL();
        }
        public Company GetinfoBycompanyId(int comid)
        {
            return company.GetinfoBycompanyID(comid);
        }
        
    }
}