
using Final_XAML.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Final_XAML.Services
{
    public class EquipmentServices : ServicePage, ImySqlConnectable
    {
        List<Equipment> equipments = new List<Equipment>();

        public void LoadFromDatabase()
        {
            equipments.Clear();
            string query = "SELECT * FROM equipment";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Equipment _ = new Equipment((int)dataReader["equipmentId"], (int)dataReader["gymID"], (string)dataReader["equipmenttype"], (byte)dataReader["weightLBS"]);

                    equipments.Add(_);
                }

                dataReader.Close();
                this.CloseConnection();
            }
            else
            {
                Debug.WriteLine("Unable to load and list using select");
            }
        }

        public void AddToDatabase(int equipmentId, int gymID, string equipmenttype, byte weightLBS)
        {
            string query = $"INSERT INTO equipment (equipmentId, gymID, equipmenttype, weightLBS) VALUES ({equipmentId}, {gymID}, '{equipmenttype}', {weightLBS})";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void UpdateRecord(int equipmentId, int gymID, string equipmenttype, byte weightLBS)
        {
            string query = $"UPDATE equipment SET gymID={gymID}, equipmenttype='{equipmenttype}', weightLBS={weightLBS} WHERE equipmentId={equipmentId}";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            else
            {
                Console.WriteLine("Connection not open, cannot update!");
            }
        }
    }
}

