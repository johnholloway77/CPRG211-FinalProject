using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3_Final.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Project3_Final.Services
{
    public class TrainerServices : ServicePage, ImySqlConnectable
    {
        List<Trainer> trainers = new List<Trainer>();

        public void LoadFromDatabase()
        {
            trainers.Clear();
            string query = "SELECT * FROM trainers";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Trainer _ = new Trainer((int)dataReader["trainerId"], (string)dataReader["firstName"], (string)dataReader["lastName"], (string)dataReader["phoneNumber"], (string)dataReader["email"], (int)dataReader["baseSalary"], (int)dataReader["hourlyFee"], (string)dataReader["certification"]);

                    trainers.Add(_);
                }

                dataReader.Close();
                CloseConnection();
            }
            else
            {
                Debug.WriteLine("Unable to load and list using select");
            }
        }

        public void AddToDatabase(int trainerId, string firstName, string lastName, string phoneNumber, string email, int baseSalary, int hourlyFee, string certification)
        {
            string query = $"INSERT INTO trainers (trainerId, firstName, lastName, phoneNumber, email, baseSalary, hourlyFee, certification) VALUES ({trainerId}, '{firstName}', '{lastName}', '{phoneNumber}', '{email}', {baseSalary}, {hourlyFee}, '{certification}')";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void UpdateRecord(int trainerId, string firstName, string lastName, string phoneNumber, string email, int baseSalary, int hourlyFee, string certification)
        {
            string query = $"UPDATE trainers SET firstName='{firstName}', lastName='{lastName}', phoneNumber='{phoneNumber}', email='{email}', baseSalary={baseSalary}, hourlyFee={hourlyFee}, certification='{certification}' WHERE trainerId={trainerId}";

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
