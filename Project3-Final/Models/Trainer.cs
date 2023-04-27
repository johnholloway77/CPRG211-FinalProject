/*
 * File for object Trainer
 * 
 * Customers inherit from object Person and use some of the fields and methods within. 
 * 
 * This method contains basic fields,such as trainerID (the primary key for the trainer table in the MySQL database), as well as other inforamtion such as date of birth, memberhsip type, etc.
 * 
 * Date: 27 April 2023
 * By: John Holloway and Victor Odhiambo

 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Models
{
	public class Trainer: Person
    {
		private int trainerId;
		private int baseSalary;
		private int hourlyFee;
		private string certification;

		public Trainer(int trainerId, string firstName, string lastName, string phoneNumber, string email, int baseSalary, int hourlyFee, string certification, bool accountStatus)
		{
			this.trainerId = trainerId;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.PhoneNumber = phoneNumber;
			this.Email = email;
			this.baseSalary = baseSalary;
			this.hourlyFee = hourlyFee;
			this.certification = certification;
			this.AccountStatus = accountStatus;

        }

		public int TrainerId { get => trainerId; set => trainerId = value; }
		public int BaseSalary { get => baseSalary; set => baseSalary = value; }
		public int HourlyFee { get => hourlyFee; set => hourlyFee = value; }
		public string Certification { get => certification; set => certification = value; }

		public override string ToString()
		{
			return $"{TrainerId}" + base.ToString() + $"{BaseSalary}:{HourlyFee}:{Certification}:{AccountStatus}";
		}


        /*
        The method  OnAccountStatusChanged() is use to detect if accountStatus changes its value. It contains a if statement to check the variable personInitialized is true. The variable personInitialized is initially set to false when object is created. The first time the method is run this variable will be set to true, allowing the method AccountStatusChanged() to run the second time it is invoked.
        This is to prevent the application from checking if the object has any active personal training sessions when it is created..
        */
        protected override void OnAccountStatusChanged()
        {

			if (!this.personInitialized) //if first initialization set bool to true
            {
                this.personInitialized = true;
            }

			else //if object is already initialized, allow it to run functions
			{

                this.AccountStatusChanged = true;
            }
            
        }
    }
}


