using System;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class CompanyDAL
    {
        private string query;
        private MySqlConnection connection;
        private MySqlDataReader reader;
         public CompanyDAL(){
            
                if (connection == null)
            {
                // connection = DBHelper.OpenConnection();
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                
            }
        }
        public Company GetinfoBycompanyID(int comid)
        {
                if (connection == null)
            {
                // connection = DBHelper.OpenConnection();
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                
            }
           
             query = @"select com_name,com_represent,com_title,com_tax,com_accountnumber,com_headquarters,com_sdt from Company where com_id = '" +comid + "';";
             Company company = null;
            reader = DBHelper.ExecQuery(query,connection);

            
            
                if (reader.Read())
                {
                    company = GetCompanyInfo(reader);
                }
                connection.Close();
            
          
            
            return company;
        }

        private Company GetCompanyInfo(MySqlDataReader reader)
        {
            Company company = new Company();
            company.AccountNumber = reader.GetString("com_accountnumber");
            company.CompanyName =  reader.GetString("com_name");
            company.Represent = reader.GetString("com_represent");
            company.Tax = reader.GetString("com_tax");
            company.Title = reader.GetString("com_title");
            company.HeadQuarters = reader.GetString("com_headquarters");
            company.Phone = reader.GetString("com_sdt");
           return company;
        }
    }
}