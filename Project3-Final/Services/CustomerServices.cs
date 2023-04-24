using Project3_Final.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Services
{
    public class CustomerServices : ServicePage //, ImySqlConnectable
    {
        //Initialize List<Customers> which will store the Customer Objects to be manipulated.

        public static List<Customer> customers = new List<Customer>();

        public static void LoadFromDatabase()
        {
            

            //ensure that List<Customers> is empty whenever method is run. Will prevent duplication in List
            customers.Clear();

            //Query string will select all rows of data from table customers
            string query = "SELECT * FROM customers";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();


                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Customer _ = new Customer((int)dataReader["custID"], (string)dataReader["firstName"], (string)dataReader["lastName"], (string)dataReader["phoneNumber"], (string)dataReader["email"], (DateTime)dataReader["dateOfBirth"], (string)dataReader["membershipType"], (bool)dataReader["accountStatus"]);

                    customers.Add(_);

                }

                dataReader.Close();

                CloseConnection();

            }
            else
            {
                Debug.WriteLine("Unable to load and list using select");
            }

        }

        public static void AddToDatabase(int custID, string firstName, string lastName, string phoneNumber, string email, string dateOfBirth, string membershipType, bool accountStatus)
        {
            string query = $"INSERT INTO customers (custID, firstName, lastName, phoneNumber, email, dateOfBirth, membershipType, accountStatus) VALUES ({custID}, {firstName}, {lastName}, {phoneNumber}, {email}, STR_TO_DATE('{dateOfBirth}', '%Y-%m-%d'), {membershipType}, {accountStatus})";


            if (OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //execute command
                cmd.ExecuteNonQuery();

                //close
                CloseConnection();
            }
        }


        public static void UpdateRecord(int custID, string firstName, string lastName, string phoneNumber, string email, DateTime dateOfBirth, string membershipType, bool accountStatus)
        {
            string query = $"UPDATE customers SET firstName='{firstName}', lastName='{lastName}', phoneNumber='{phoneNumber}', email='{email}', dateOfBirth=STR_TO_DATE('{dateOfBirth.ToString("yyyy-MM-dd")}','%Y-%m-%d'), membershipType='{membershipType}', accountStatus={accountStatus}  WHERE custID='{custID}'";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = query;

                cmd.Connection = connection;

                cmd.ExecuteNonQuery();

                CloseConnection();
            }
            else
            {
                Console.WriteLine("Connection not open, cannot update!");
            }
        }

       


    }
}
