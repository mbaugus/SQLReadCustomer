using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SqlLib
{
    public class SqlCustomer
    {
        public List<Customer> List()
        {
            try
            {
                string Server = @"DESKTOP-N2UK58T\SQLEXPRESS";
                string Database = "SqlTutorial";
               
                string connectionString = $"server={Server};database={Database};Trusted_connection=true";
                SqlConnection connection = new SqlConnection(connectionString);
  
                connection.Open();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connection didnt open.");
                    return null;
                }
                else
                {
                    Console.WriteLine("Connection open succesful.");
                }

                string sql = "select * from customer";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    Console.WriteLine("result has no rows.");
                    return null;
                }

                int idIndex = reader.GetOrdinal("Id");
                int nameIndex = reader.GetOrdinal("Name");
                int cityIndex = reader.GetOrdinal("City");
                int stateIndex = reader.GetOrdinal("State");
                int isCorpAcctIndex = reader.GetOrdinal("IsCorpAcct");
                int credLimitIndex = reader.GetOrdinal("CreditLimit");
                int activeIndex = reader.GetOrdinal("Active");

                List<Customer> returnList = new List<Customer>();

                while (reader.Read())
                {
                    int id = reader.GetInt32(idIndex);
                    string name = reader.GetString(nameIndex);
                    string city = reader.GetString(cityIndex);
                    string state = reader.GetString(stateIndex);
                    bool isCorpAcct = reader.GetBoolean(isCorpAcctIndex);
                    int creditLimit = reader.GetInt32(credLimitIndex);
                    bool active = reader.GetBoolean(activeIndex);

                    Customer customer = new Customer();
                    customer.Id = id;
                    customer.Name = name;
                    customer.City = city;
                    customer.State = state;
                    customer.IsCorpAcct = isCorpAcct;
                    customer.CreditLimit = creditLimit;
                    customer.Active = active;

                    returnList.Add(customer);
                }

                connection.Close();
                return returnList;
            }

            catch (System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        
    }
}
