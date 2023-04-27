/*
 Customer Services is a class which contains primarily static methods for the manipulation of Customer objects, as well as updating the database for the respective object.

Inherits several methods from class ServicePage
 
 */

using Project3_Final.Models;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace Project3_Final.Services
{
    public class CustomerServices : ServicePage 
    {
        //Initialize List<Customers> which will store the Customer Objects to be manipulated.
        //List<Customer> exist for all Customers found in the SQL database, as well as a list for those whose status is active
        public static List<Customer> customers = new List<Customer>();
        public static List<Customer> activeCustomers = new List<Customer>();

        //Initialize customerDictionary. Dictionary will input custID and return first & last name
        public static Dictionary<int, string> customerDictionary = new Dictionary<int, string>();

        public static void LoadFromDatabase()
        {
            

            //ensure that List<Customers> is empty whenever method is run. Will prevent duplication in List
            customers.Clear();
            activeCustomers.Clear();

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

                    //add to list<Customers> customers
                    customers.Add(_);
                    
                    //add object instance to trainerDictionary
                    AddToCustomerDictionary(_.CustID, _.FirstName, _.LastName);

                    //if object instance is active add to List<T> active<t>
                    if ((bool)dataReader["accountStatus"])
                    {
                        activeCustomers.Add(_);
                    }
                }

                dataReader.Close();

                CloseConnection();

            }
            else
            {
                Debug.WriteLine("Unable to load and list using select");
            }

        }

        public static void AddToDatabase(int custID, string firstName, string lastName, string phoneNumber, string email, DateTime dateOfBirth, string membershipType, bool accountStatus)
        {
            string query = $"INSERT INTO customers (custID, firstName, lastName, phoneNumber, email, dateOfBirth, membershipType, accountStatus) VALUES ({custID}, '{firstName}', '{lastName}', '{phoneNumber}', '{email}', STR_TO_DATE('{dateOfBirth.ToString("yyyy-MM-dd")}','%Y-%m-%d'), '{membershipType}', {accountStatus})";


            Debug.WriteLine(query);

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

        private static void AddToCustomerDictionary(int custID, string firstName, string lastName)
        {
            customerDictionary[custID] = $"{firstName} {lastName}";


        }

    }
}
