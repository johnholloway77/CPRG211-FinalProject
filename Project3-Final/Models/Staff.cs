/*
 * File for object Staff
 * 
 * Customers inherit from object Person and use some of the fields and methods within. 
 * 
 * This method contains basic fields,such as staffID (the primary key for the staff table in the MySQL database), as well as other inforamtion such as date of birth, memberhsip type, etc.
 * 
 * Date: 27 April 2023
 * By: John Holloway and Victor Odhiambo

 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Models
{
	public class Staff : Person
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


		/* 
		* The method  OnAccountStatusChanged() does not return or perform any operations as staff members cannot book personal training sessions.However, the function must exist as it is inherited from the abstract method within base class.
		 */ 
        protected override void OnAccountStatusChanged()
        {

        }
    }
}
