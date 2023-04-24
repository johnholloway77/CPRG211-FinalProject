using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Services
{
    public abstract class ServicePage
    {
        static internal MySqlConnection connection;
        static internal string server;
        static internal string port;
        static internal string database;
        static internal string uid;
        static internal string password;

        public ServicePage()
        {
            Initialize();
        }

        public static void Initialize()
        {
            

            server = "johnholloway.ca";
            port = "3306";
            database = "cprg211f";
            uid = "admin";
            password = "cprgpass";


            string connectingString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectingString);
        }

        //open connection to DB
        internal static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact Adminsitrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password. Please try again");
                        break;
                }
                Console.WriteLine("MySQL response: " + ex.Message);
                Console.WriteLine("MySQL response: " + ex.Number);
                return false;
            }
        }

        //close connection  to Db
        internal static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


    }
}
