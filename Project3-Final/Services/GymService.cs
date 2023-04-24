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
    public class GymService : ServicePage, ImySqlConnectable
    {
        List<Gym> gyms = new List<Gym>();

        public void LoadFromDatabase()
        {
            gyms.Clear();

            string query = "SELECT * FROM gyms";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Gym gym = new Gym((int)dataReader["gymID"], (string)dataReader["street"], (string)dataReader["city"], (string)dataReader["province"], (string)dataReader["postal"]);

                    gyms.Add(gym);
                }

                dataReader.Close();

                CloseConnection();
            }
            else
            {
                Debug.WriteLine("Unable to load and list using select");
            }
        }

        public void AddToDatabase(int gymID, string street, string city, string province, string postal)
        {
            string query = $"INSERT INTO gyms (gymID, street, city, province, postal) VALUES ({gymID}, '{street}', '{city}', '{province}', '{postal}')";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                CloseConnection();
            }
        }

        public void UpdateRecord(int gymID, string street, string city, string province, string postal)
        {
            string query = $"UPDATE gyms SET street='{street}', city='{city}', province='{province}', postal='{postal}' WHERE gymID='{gymID}'";

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
