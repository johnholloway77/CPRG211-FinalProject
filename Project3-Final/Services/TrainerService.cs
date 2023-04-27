/*
 TrainerServices is a class which contains primarily static methods for the manipulation of Trainer objects, as well as updating the database for the respective object.

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
using System.Diagnostics;


namespace Project3_Final.Services
{
    public class TrainerServices : ServicePage
    {
        //Initialize List<TrainingSession> which will store the Trainer Objects to be manipulated.
        public static List<Trainer> trainers = new List<Trainer>();

        public static List<Trainer> activeTrainers = new List<Trainer>();

        //Initialize trainerDictionary. Dictionary will input trainerID and return first & last name
        public static Dictionary<int, string> trainerDictionary = new Dictionary<int, string>();

        public static void LoadFromDatabase()
        {
            trainers.Clear();
            activeTrainers.Clear();

            string query = "SELECT * FROM trainers";
            
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
                    Trainer _ = new Trainer((int)dataReader["trainerId"], (string)dataReader["firstName"], (string)dataReader["lastName"], (string)dataReader["phoneNumber"], (string)dataReader["email"], (int)dataReader["baseSalary"], (int)dataReader["hourlyFee"], (string)dataReader["certification"], (bool)dataReader["employmentStatus"]);

                    //add to list<Trainer> trainers
                    trainers.Add(_);

                    //add object instance to trainerDictionary
                    AddToTrainerDictionary(_.TrainerId, _.FirstName, _.LastName);
                    
                    //if object instance is active add to List<T> active<t>
                    if ((bool)dataReader["employmentStatus"])
                    {
                        activeTrainers.Add(_);
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
            catch (InvalidCastException ex)
            {
                Debug.WriteLine("Error casting value from database. Check database data type and if null\n" + ex.Message);
            }
            finally //Close connection to prevent InvalidOperationException
            {
                CloseConnection();
}
        
        }

        public static void AddToDatabase(int trainerId, string firstName, string lastName, string phoneNumber, string email, int baseSalary, int hourlyFee, string certification, bool accountStatus)
        {
            string query = $"INSERT INTO trainers (trainerId, firstName, lastName, phoneNumber, email, baseSalary, hourlyFee, certification, employmentStatus) VALUES ({trainerId}, '{firstName}', '{lastName}', '{phoneNumber}', '{email}', {baseSalary}, {hourlyFee}, '{certification}', {accountStatus})";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public static void UpdateRecord(int trainerId, string firstName, string lastName, string phoneNumber, string email, int baseSalary, int hourlyFee, string certification, bool accountStatus)
        {
            string query = $"UPDATE trainers SET firstName='{firstName}', lastName='{lastName}', phoneNumber='{phoneNumber}', email='{email}', baseSalary={baseSalary}, hourlyFee={hourlyFee}, certification='{certification}', employmentStatus={accountStatus} WHERE trainerId={trainerId}";

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

        private static void AddToTrainerDictionary(int trainerID, string firstName, string lastName)
        {
            trainerDictionary[trainerID] = $"{firstName} {lastName}";


        }
    
    }
}
