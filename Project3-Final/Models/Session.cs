/*
 File for personal training objects.
 Contains sessionID, which is primary key in MySQL database, and several other IDs which are foriegn keys in the database.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Models
{
    public class Session
    {
        private int sessionID;
        private int trainerID;
        private int custID;
        private int gymID;
        private DateTime sessionDate;
        private bool sessionStatus;

        public Session(int sessionID, int trainerID, int custID, int gymID, DateTime sessionDate, bool sessionStatus)
        {
            this.sessionID = sessionID;
            this.trainerID = trainerID;
            this.custID = custID;
            this.gymID = gymID;
            this.sessionDate = sessionDate;
            this.sessionStatus = sessionStatus;
        }

        public int SessionID { get => sessionID; set => sessionID = value; }
        public int TrainerID { get => trainerID; set => trainerID = value; }
        public int CustID { get => custID; set => custID = value; }
        public int GymID { get => gymID; set => gymID = value; }
        public DateTime SessionDate { get => sessionDate; set => sessionDate = value; }
        public bool SessionStatus { get => sessionStatus; set => sessionStatus = value; }
    }
}
