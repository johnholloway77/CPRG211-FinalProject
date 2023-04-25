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
    public class GymService : ServicePage //, ImySqlConnectable
    {
        public static List<Gym> gyms = new List<Gym>();

        public static void LoadFromDatabase()
        {
            gyms.Clear();

            string query = "SELECT * FROM gym";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Gym _ = new Gym((int)dataReader["gymID"], (string)dataReader["street"], (string)dataReader["city"], (string)dataReader["prov"], (string)dataReader["postalCode"]);

                    gyms.Add(_);
                }

                dataReader.Close();

                CloseConnection();
            }
            else
            {
                Debug.WriteLine("Unable to load and list using select");
            }
        }

        public static void AddToDatabase(int gymID, string street, string city, string province, string postal)
        {
            string query = $"INSERT INTO gym (gymID, street, city, prov, postalCode) VALUES ({gymID}, '{street}', '{city}', '{province}', '{postal}')";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                CloseConnection();
            }
        }

        public static void UpdateRecord(int gymID, string street, string city, string province, string postal)
        {
            string query = $"UPDATE gym SET street='{street}', city='{city}', prov='{province}', postalCode='{postal}' WHERE gymID='{gymID}'";

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
