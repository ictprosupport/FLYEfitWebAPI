using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FLYEfitWebAPI
{
    public class Database_MySQL
    {
        //private const string CONNECTION_STRING = "server=185.52.24.249;user id=flyefit_myf;password=xRsw9wL3fjVHfBVeTyaRw;persistsecurityinfo=True;port=3306;database=flyefit_myf";
        private const string CONNECTION_STRING = "server=31.170.123.102;user id=flyefit_myf;password=xRsw9wL3fjVHfBVeTyaRw;persistsecurityinfo=True;port=3306;database=flyefit_myf_test";
        private MySqlConnection connection = new MySqlConnection { ConnectionString = CONNECTION_STRING };


        public void open()
        {
            connection.Open();
        }

        public void close()
        {
            connection.Close();
        }

        public MySqlDataReader getData(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            //MySqlDataReader reader = command.ExecuteReader();            
            return command.ExecuteReader();
        }

        public MySqlDataReader getData(string query, Dictionary<string, string> Parameters)
        {
            MySqlCommand command = new MySqlCommand(query, connection);

            if (Parameters.Count > 0)
            {
                foreach (KeyValuePair<string, string> myParam in Parameters)
                {
                    command.Parameters.AddWithValue(myParam.Key, myParam.Value);
                }
            }

            //MySqlDataReader reader = command.ExecuteReader();            
            return command.ExecuteReader();
        }

    }
}
