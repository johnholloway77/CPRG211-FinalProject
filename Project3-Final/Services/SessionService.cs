using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3_Final.Models;
//using MySqlX.XDevAPI;

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



        //Function will check if customer/trainer has active training sessions, return tuple with
        //bool indicating if the user does or not, and a list<sessions> containing all of the sessions in which
        //the person is involved
        public static Tuple<bool, List<Session>> CheckForActiveSessions(Type personType, int personID)
        {
            bool hasActiveSessions = false;
            List<Session> personSessions = new List<Session>();

            Debug.WriteLine("1. Type.Name= " + personType.Name);

            //check what type of object called function, adjust checkID appropriately.
            //Because a Customer, Trainer or Gym can have the same number for their ID a 
            //switch is needed to run specific foreach loops
            switch (personType.Name)
            {
                case "Customer":
                    {
                        Debug.WriteLine("2. Type.Name= " + personType.Name + " = \"Customer\"");

                        foreach (Session session in SessionService.activeSessions)
                        {
                            if (session.CustID == personID)
                            {
                                hasActiveSessions = true;
                                personSessions.Add(session);
                            }
                        }

                        break;
                    }
                case "Trainer":
                    {
                        Debug.WriteLine("2. Type.Name= " + personType.Name + " = \"Trainer\"");

                        foreach (Session session in SessionService.activeSessions)
                        {
                            if (session.TrainerID == personID)
                            {
                                hasActiveSessions = true;
                                personSessions.Add(session);
                            }
                        }

                        break;
                    }

             }


            
            return Tuple.Create(hasActiveSessions, personSessions);

        }

        public static void DeactivateSessions(List<Session> sessions)
        {
            Debug.WriteLine("List<Sessions> session.Count = " +  sessions.Count);

            foreach (Session session in sessions)
            {
                string query = $"UPDATE session SET sessionstatus=FALSE WHERE sessionID={session.SessionID};";

                Debug.WriteLine (query);


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
}
