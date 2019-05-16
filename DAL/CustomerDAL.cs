using System;
using Persistence;
using MySql.Data.MySqlClient;


namespace DAL
{
    public class CustomerDAL
    {
        private string query;
        private MySqlDataReader reader;
        public Customer GetCustomerbyID(int cusID)
        {
            query = @"select customer_id, customer_name, customer_address from
            customer where customer_id = '"+ cusID+ "';";
            DBHelper.OpenConnection();
            reader = DBHelper.ExcQuery(query);

            Customer customer = null;
            if(reader.Read())
            {
                customer = GetCustomerInfo(reader);
            }
            DBHelper.CloseConnection();
            return customer;
        }
        private Customer GetCustomerInfo(MySqlDataReader reader)
        {
            Customer cus = new Customer();
            cus.CustomerId = reader.GetInt16("customer_id");
            cus.CustomerName = reader.GetString("customer_name");
            cus.CustomerAddress = reader.GetString("customer_address");
            cus.PhoneNumber = reader.GetString("phone_number");
            return cus;
        }
        public Customer GetCustomer()
        {
            query = @"select * from Customer;";
            DBHelper.OpenConnection();
            reader = DBHelper.ExcQuery(query);

            Customer customer = null;
            if(reader.Read())
            {
                customer = GetCustomerInfo(reader);
            }
            DBHelper.CloseConnection();
            return customer;
        }
        public void InsertCustomer(int cusID, string cusName, string cusAddress, string Phone)
        {
            query =@"insert into Customer value('"+cusID+"','" +cusName+"','"+cusAddress+"','"+Phone+"');";
            DBHelper.OpenConnection();
            reader = DBHelper.ExcQuery(query);

            Customer customer = null;
            if(reader.Read())
            {
                customer = GetCustomerInfo(reader);
            }
            DBHelper.CloseConnection(); 
        }

    }
}