using System;
using Persistence;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class CustomerDAL
    {
        private string query;
        //  DBHelper db = DBHelper.GetInstance();
        private MySqlConnection connection;
        private MySqlDataReader reader;

        public CustomerDAL()
        {
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public Customer GetCustomerbyID(int cusID)
        {

            query = @"select customer_id, customer_name, customer_address, phone_number from
            customer where customer_id = " + cusID + ";";
            Customer customer = null;
            reader = DBHelper.ExecQuery(query, connection);
            if (reader.Read())
            {
                customer = GetCustomerInfo(reader);
            }
            connection.Close();
            return customer;
        }
        public Customer GetCustomerInfo(MySqlDataReader reader)
        {
            Customer cus = new Customer();
            cus.CustomerId = reader.GetInt32("customer_id");
            cus.CustomerName = reader.GetString("customer_name");
            cus.CustomerAddress = reader.GetString("customer_address");
            cus.PhoneNumber = reader.GetString("phone_number");
            return cus;
        }
        public List<Customer> GetCustomer()
        {
            query = @"select * from customer;";
            // DBHelper.OpenConnection();
            // DBHelper.Instance.OpenConnection();
            // reader = DBHelper.ExcQuery(query);
            reader = DBHelper.ExecQuery(query, connection);
            List<Customer> customer = new List<Customer>();

            while (reader.Read())
            {
                customer.Add(GetCustomerInfo(reader));
            }
            // DBHelper.CloseConnection();
            connection.Close();
            return customer;

        }
        public bool InsertCustomer(string cusName, string cusAddress, string Phone)
        {
            bool result = true;
            if (cusName == null || cusAddress == null || Phone == null)
            {
                return false;
            }
            // if ()
            // {
            //     return false;
            // }
            query = @"insert into Customer(customer_name,customer_address,phone_number) value('" + cusName + "','" + cusAddress + "','" + Phone + "');";

            reader = DBHelper.ExecQuery(query, connection);
            Customer customer = null;
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                if (reader.Read())
                {
                    customer = GetCustomerInfo(reader);

                }
                // DBHelper.CloseConnection();  
                connection.Close();
                return true;
            }
            catch (System.Exception)
            {
                result = false;

            }

            return result;

        }
        public bool UpdateCustomer(int id, string name, string address, string sdt)
        {
            bool result = true;

            if (name == null || address == null || sdt == null)
            {
                return false;
            }
              if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"update customer set customer_name ='" + name + "', customer_address ='" + address + "',phone_number ='" + sdt +
            "'where customer_id = " + id + ";";

            reader = DBHelper.ExecQuery(query, connection);

            Customer customer = null;
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                
                if (reader.Read())
                {
                    customer = GetCustomerInfo(reader);
                }
                // DBHelper.CloseConnection();
                connection.Close();
                return true;
            }
            catch (System.Exception)
            {
                result = false;

            }

            return result;

        }


    }
}