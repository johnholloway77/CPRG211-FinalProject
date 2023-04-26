using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3_Final.Models;

namespace Project3_Final.Services
{
    internal class SessionService: ServicePage
    {        //Initialize List<Session> which will store the session Objects to be manipulated.
        public static List<Session> sessions = new List<Session>();
        public static List<Session> activeSessions = new List<Session>();

        public static void LoadFromDatabase()
        {
            sessions.Clear();
            activeSessions.Clear();

            string query = "SELECT * FROM session";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Session _ = new Session((int)dataReader["sessionID"], (int)dataReader["trainerID"], (int)dataReader["custID"], (int)dataReader["gymID"], (DateTime)dataReader["sessionDate"], (bool)dataReader["sessionStatus"]);

                    //add to list<Sessions> sessions
                    sessions.Add(_);

                    if ((bool)dataReader["sessionStatus"])
                    {
                        activeSessions.Add(_);
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

        public static void AddToDatabase(int sessionID, int trainerID, int custID, int gymID, DateTime sessionDate, bool sessionStatus)
        {
            string query = $"INSERT INTO session (sessionID, trainerID, custID, gymID, sessionDate, sessionstatus) VALUES ({sessionID}, {trainerID}, {custID}, {gymID}, STR_TO_DATE('{sessionDate.ToString("yyyy-MM-dd H mm")}','%Y-%m-%d %k %i'), {sessionStatus})";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public static void UpdateRecord(int sessionID, int trainerID, int custID, int gymID, DateTime sessionDate, bool sessionStatus)
        {
            string query = $"UPDATE session SET trainerID={trainerID}, custID={custID}, gymID={gymID}, sessionDate=STR_TO_DATE('{sessionDate.ToString("yyyy-MM-dd H mm")}','%Y-%m-%d %k %i'), sessionstatus={sessionStatus} WHERE sessionID={sessionID}";

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
