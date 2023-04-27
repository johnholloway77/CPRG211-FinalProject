/*
 * File for object Gym
 * 
 * Customers inherit from object Person and use some of the fields and methods within. 
 * 
 * This method contains basic fields,such as gymID (the primary key for the gym table in the MySQL database), as well as other inforamtion such as date of birth, memberhsip type, etc.

Additionally, it contains the abstract method gymStatusChanged()
This method is used  to see if the active/inactive status of the gym instance is changed. Methods will use this bool to run additional methods scanning if a gym has been set to inactive while having active personal training sessions. 


*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Models
{
	public class Gym
	{
		private int gymID;
		private string street;
		private string city;
		private string province;
		private string postal;
		private string location;

		private bool gymStatus;
		private bool gymInitialized;
		private bool gymStatusChanged;

		public Gym(int gymID, string street, string city, string province, string postal, bool gymStatus)
		{
			this.gymID = gymID;
			this.street = street;
			this.city = city;
			this.province = province;
			this.postal = postal;
			this.gymStatus = gymStatus;
		}

		public int GymID { get => gymID; set => gymID = value; }
		public string Street { get => street; set => street = value; }
		public string City { get => city; set => city = value; }
		public string Province { get => province; set => province = value; }
		public string Postal { get => postal; set => postal = value; }
		public string Location { get => location; set => location = value; }
		public bool GymStatus
		{
			get => gymStatus;
			set
			{
				gymStatus = value;
				OnGymStatusChanged();
			}
		}

		public bool GymStatusChanged { get => gymStatusChanged; set => gymStatusChanged = value; }

		public override string ToString()
		{
			return $"{GymID}" + base.ToString() + $"{Street}:{City}:{Province}:{Postal}:{gymStatus}";
		}

        /*
		The method  OnGymStatusChanged() is use to detect if accountStatus changes its value. It contains a if statement to check the variable gymInitialized is true. The variable personInitialized is initially set to false when object is created. The first time the method is run this variable will be set to true, allowing the method OnGymStatusChanged() to run the second time it is invoked.
		This is to prevent the application from checking if the object has any active personal training sessions when it is created..
		*/
        private void OnGymStatusChanged()
		{
			if (!this.gymInitialized) //if first initialized set bool to true
			{
				this.gymInitialized = true;
			}
			else //if object is already initialized, all it to run functions
			{
				this.GymStatusChanged = true;
			}

		}
	}
}
