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
    public class StaffServices : ServicePage //, ImySqlConnectable
    {
        public static List<Staff> staffs = new List<Staff>();

        public static void LoadFromDatabase()
        {
            staffs.Clear();
            string query = "SELECT * FROM staff";

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
