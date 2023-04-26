using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Models
{
	public class Staff:Person
	{
		private int staffID;
		private int gymID;
		private int salary;
		private string position;

		public Staff(int staffID, int gymID, string firstName, string lastName, string phoneNumber, string email, int salary, string position, bool accountStatus)
		{
			this.StaffID = staffID;
			this.GymID = gymID;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.PhoneNumber = phoneNumber;
			this.Email = email;
			this.Salary = salary;
			this.Position = position;
			this.AccountStatus = accountStatus;
		}

		public int StaffID { get => staffID; set => staffID = value; }
		public int Salary { get => salary; set => salary = value; }
		public string Position { get => position; set => position = value; }
        public int GymID { get => gymID; set => gymID = value; }

        public override string ToString()
		{
			return $"{StaffID}:{GymID}" + base.ToString() + $"{Salary}:{Position}:{AccountStatus}";
		}
	}
}
