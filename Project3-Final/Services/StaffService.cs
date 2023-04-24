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
    public class StaffServices : ServicePage, ImySqlConnectable
    {
        List<Staff> staffs = new List<Staff>();

        public void LoadFromDatabase()
        {
            staffs.Clear();
            string query = "SELECT * FROM staff";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Staff _ = new Staff((int)dataReader["staffID"], (string)dataReader["firstName"], (string)dataReader["lastName"], (string)dataReader["phoneNumber"], (string)dataReader["email"], (int)dataReader["salary"], (string)dataReader["postion"]);

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

        public void AddToDatabase(int staffID, string firstName, string lastName, string phoneNumber, string email, int salary, string postion)
        {
            string query = $"INSERT INTO staff (staffID, firstName, lastName, phoneNumber, email, salary, postion) VALUES ({staffID}, '{firstName}', '{lastName}', '{phoneNumber}', '{email}', {salary}, '{postion}')";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void UpdateRecord(int staffID, string firstName, string lastName, string phoneNumber, string email, int salary, string postion)
        {
            string query = $"UPDATE staff SET firstName='{firstName}', lastName='{lastName}', phoneNumber='{phoneNumber}', email='{email}', salary={salary}, postion='{postion}' WHERE staffID={staffID}";

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
