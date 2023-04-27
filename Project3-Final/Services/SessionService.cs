/*
 SessionServices is a class which contains primarily static methods for the manipulation of session objects, as well as updating the database for the respective object.

Inherits several methods from class ServicePage

Unlike other service files, this file contains additional methods for 

 */

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



        /*
         Function will check if customer/trainer/gym has active training sessions
        
        CheckForActiveSessions will receive input of Type identifying the type of object which called the method, and return tuple<bool, List<session>> with the bool indicating if the person/gym has active personal training sessions, and a list<sessions> containing all of the sessions with which the person/gym is involved
        */
        public static Tuple<bool, List<Session>> CheckForActiveSessions(Type objectType, int objectID)
        {
            bool hasActiveSessions = false;
            List<Session> objectSessions = new List<Session>();

            Debug.WriteLine("1. Type.Name= " + objectType.Name);


            //check what type of object called function, adjust checkID appropriately.
            //Because a Customer, Trainer or Gym can have the same number for their ID a 
            //switch is needed to run specific foreach loops
            switch (objectType.Name)
            {
                case "Customer":
                    {
                        Debug.WriteLine("2. Type.Name= " + objectType.Name + " = \"Customer\"");

                        foreach (Session session in SessionService.activeSessions)
                        {
                            if (session.CustID == objectID)
                            {
                                hasActiveSessions = true;
                                objectSessions.Add(session);
                            }
                        }

                        break;
                    }
                case "Trainer":
                    {
                        Debug.WriteLine("2. Type.Name= " + objectType.Name + " = \"Trainer\"");

                        foreach (Session session in SessionService.activeSessions)
                        {
                            if (session.TrainerID == objectID)
                            {
                                hasActiveSessions = true;
                                objectSessions.Add(session);
                            }
                        }

                        break;
                    }
                case "Gym":
                    {
                        Debug.WriteLine("2. Type.Name= " + objectType.Name + " = \"Gym\"");

                        foreach (Session session in SessionService.activeSessions)
                        {
                            if (session.GymID == objectID)
                            {
                                hasActiveSessions = true;
                                objectSessions.Add(session);
                            }
                        }

                        break;
                    }

            }


            
            return Tuple.Create(hasActiveSessions, objectSessions);

        }


        //In method DeactivateSessions is invoked, it will recieve a List<Sessions> and go through each list, updating the MySql table for sessions. All session rows that have the matching sessionID will be set to sessionStatus=FALSE
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
