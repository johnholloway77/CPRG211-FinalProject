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

        protected override void OnAccountStatusChanged()
        {
			//check if this object instance has already been initialized or if it is its' first initialization

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


