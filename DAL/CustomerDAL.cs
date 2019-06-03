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
         
        public CustomerDAL(){
              if (connection == null)
            {
                // connection = DBHelper.OpenConnection();
                connection = DBHelper.Instance.OpenConnection();
            }
            // if (connection.State == System.Data.ConnectionState.Closed)
            // {
            //     connection = DBHelper.Instance.OpenConnection();
                
            // }
        }
        private MySqlDataReader reader;
        public Customer GetCustomerbyID(int cusID)
        {
            query = @"select customer_id, customer_name, customer_address, phone_number from
            customer where customer_id = '"+ cusID+ "';";
           
            reader = DBHelper.Instance.ExcQuery(query);
            Customer customer = null;
            
            try
            {
                 MySqlCommand command = new MySqlCommand(query, connection);
                
                 if(reader.Read())
            {
                customer = GetCustomerInfo(reader);
            }
            // DBHelper.CloseConnection();
            DBHelper.Instance.CloseConnection();
            
            }
            catch 
            {
                
              return null;
            }
           
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
           reader = DBHelper.Instance.ExcQuery(query);
            List<Customer> customer = new List<Customer>();
            
                while(reader.Read())
                {
                    customer .Add( GetCustomerInfo(reader));
                }
            // DBHelper.CloseConnection();
             DBHelper.Instance.CloseConnection();
            return customer;
            
        }
        public bool InsertCustomer( string cusName, string cusAddress, string Phone)
        {
            bool result = true;
            if (cusName == null || cusAddress == null)
            {
                return false;
            }
            if (Phone == null)
            {
                return false;
            }
            query =@"insert into Customer(customer_name,customer_address,phone_number) value('" +cusName+"','"+cusAddress+"','"+Phone+"');";
           
            reader= DBHelper.Instance.ExcQuery(query);
            Customer customer =null;
            try
            {
               MySqlCommand command = new MySqlCommand(query, connection);
               if(reader.Read())
            {
             customer = GetCustomerInfo(reader);    
             
            }
            // DBHelper.CloseConnection();  
            DBHelper.Instance.CloseConnection();
             return true;
            }
            catch (System.Exception )
            {
                result = false;

            }
            
           return result;
             
        }
        public bool UpdateCustomer (int id, string name, string address, string sdt)
        {
           bool result = true;
          
            if (name == null || address == null)
            {
                return false;
            }
            if (sdt == null)
            {
                return false;
            }
            query = @"update customer set customer_name ='"+name+"', customer_address ='"+address+"',phone_number ='"+sdt+
            "'where customer_id = '"+id+"';";
            // DBHelper.OpenConnection();
            // DBHelper.Instance.OpenConnection();
            // reader = DBHelper.ExcQuery(query);
            reader = DBHelper.Instance.ExcQuery(query);
            MySqlCommand command = new MySqlCommand(query, connection);
            Customer customer = null;
            try
            {
                
                if(reader.Read())
            {
                customer = GetCustomerInfo(reader);
            }
            // DBHelper.CloseConnection();
            
             
             DBHelper.Instance.CloseConnection(); 
             return true;
            }
            catch (System.NullReferenceException )
            {
                result =false;
                
            }
           
            return result;
            
        }
        

    }
}