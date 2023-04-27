/*
 GymServices is a class which contains primarily static methods for the manipulation of gym objects, as well as updating the database for the respective object.

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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Services
{
    public class GymService : ServicePage 
    {
        //Initialize List<Gym> which will store the Customer Objects to be manipulated.
        public static List<Gym> gyms = new List<Gym>();
        public static List<Gym> activeGyms = new List<Gym>();

        //Initialize gymDictionary. Dictionary will recieve input gymID and return street & city
        public static Dictionary<int, string> gymDictionary = new Dictionary<int, string>();
        public static void LoadFromDatabase()
        {
            gyms.Clear();
            activeGyms.Clear();

            string query = "SELECT * FROM gym";

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
                        Gym _ = new Gym((int)dataReader["gymID"], (string)dataReader["street"], (string)dataReader["city"], (string)dataReader["prov"], (string)dataReader["postalCode"], (bool)dataReader["gymStatus"]);

                        //add to list<Gym> gyms
                        gyms.Add(_);

                        //add object instance to gymDictionary
                        AddToGymDictionary((int)dataReader["gymID"], (string)dataReader["street"], (string)dataReader["city"]);

                        //add to activelist
                        if ((bool)dataReader["gymStatus"])
                        {
                            activeGyms.Add(_);
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

        public static void AddToDatabase(int gymID, string street, string city, string province, string postal, bool gymStatus)
        {
            string query = $"INSERT INTO gym (gymID, street, city, prov, postalCode, gymStatus) VALUES ({gymID}, '{street}', '{city}', '{province}', '{postal}', {gymStatus})";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                CloseConnection();
            }
        }

        public static void UpdateRecord(int gymID, string street, string city, string province, string postal, bool gymStatus)
        {
            string query = $"UPDATE gym SET street='{street}', city='{city}', prov='{province}', postalCode='{postal}', gymStatus={gymStatus} WHERE gymID='{gymID}'";

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




        internal static void AddToGymDictionary(int gymID, string street, string city)
        {
            gymDictionary[gymID] = $"{street}\n{city}";
        }

    }
}
