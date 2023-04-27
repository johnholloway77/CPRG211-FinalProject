/*
 StaffServices is a class which contains primarily static methods for the manipulation of Staff objects, as well as updating the database for the respective object.

Inherits several methods from class ServicePage
  * 
 * Date: 27 April 2023
 * By: John Holloway and Guntas Dhaliwal

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3_Final.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project3_Final.Services
{
    public class StaffServices : ServicePage
    {
        public static List<Staff> staffs = new List<Staff>();

        public static void LoadFromDatabase()
        {
            staffs.Clear();
            string query = "SELECT * FROM staff";

            //Try Catch block to incase of invalid cast exceptions
            //ie table field is null
            try
            {

                if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Staff _ = new Staff((int)dataReader["staffID"], (int)dataReader["gymID"], (string)dataReader["firstName"], (string)dataReader["lastName"], (string)dataReader["phoneNumber"], (string)dataReader["email"], (int)dataReader["salary"], (string)dataReader["position"], (bool)dataReader["employmentStatus"]);

                    staffs.Add(_);
                }

                dataReader.Close();
                CloseConnection();
            }
                else
            {
                Debug.WriteLine("Unable to load and list using select");
            }
            }
            catch (InvalidCastException ex)
            {
                Debug.WriteLine("Error casting value from database. Check database data type and if null\n" + ex.Message);
            }
            finally //Close connection to prevent InvalidOperationException
            {
                CloseConnection();
            }
        }

        public static void AddToDatabase(int staffID, int gymID, string firstName, string lastName, string phoneNumber, string email, int salary, string position, bool accountStatus)
        {
            string query = $"INSERT INTO staff (staffID, gymID, firstName, lastName, phoneNumber, email, salary, position, employmentStatus) VALUES ({staffID}, {gymID}, '{firstName}', '{lastName}', '{phoneNumber}', '{email}', {salary}, '{position}', {accountStatus})";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public static void UpdateRecord(int staffID, int gymID, string firstName, string lastName, string phoneNumber, string email, int salary, string position, bool accountStatus)
        {
            string query = $"UPDATE staff SET gymID={gymID}, firstName='{firstName}', lastName='{lastName}', phoneNumber='{phoneNumber}', email='{email}', salary={salary}, position='{position}', employmentStatus={accountStatus} WHERE staffID={staffID}";

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
