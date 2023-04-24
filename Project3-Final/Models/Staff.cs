using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Models
{
	public class Staff:Person
	{
		private int staffID;
		private int salary;
		private string postion;

		public Staff(int staffID, string firstName, string lastName, string phoneNumber, string email, int salary, string postion)
		{
			this.staffID = staffID;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.PhoneNumber = phoneNumber;
			this.Email = email;
			this.salary = salary;
			this.postion = postion;
		}

		public int StaffID { get => staffID; set => staffID = value; }
		public int Salary { get => salary; set => salary = value; }
		public string Postion { get => postion; set => postion = value; }

		public override string ToString()
		{
			return $"{StaffID}:" + base.ToString() + $"{Salary}:{Postion}:{AccountStatus}";
		}
	}
}
