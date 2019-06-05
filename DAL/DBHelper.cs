﻿using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DBHelper
    {
        public static MySqlConnection OpenConnection()
        {
            try
            {
                string conString;
                using (FileStream fileStream = File.OpenRead("ConnectionString.txt"))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        conString = reader.ReadLine();
                    }
                }
                return OpenConnection(conString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public static MySqlConnection OpenConnection(string connectionString)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();
                return connection;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static MySqlDataReader ExecQuery(string query, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteReader();
        }
    }
}