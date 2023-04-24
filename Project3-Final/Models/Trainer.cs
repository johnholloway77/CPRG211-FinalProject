using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Models
{
	public class Trainer:Person
	{
		private int trainerId;
		private int baseSalary;
		private int hourlyFee;
		private string certification;

		public Trainer(int trainerId, string firstName, string lastName, string phoneNumber, string email, int baseSalary, int hourlyFee, string certification)
		{
			this.trainerId = trainerId;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.PhoneNumber = phoneNumber;
			this.Email = email;
			this.baseSalary = baseSalary;
			this.hourlyFee = hourlyFee;
			this.certification = certification;
		}

		public int TrainerId { get => trainerId; set => trainerId = value; }
		public int BaseSalary { get => baseSalary; set => baseSalary = value; }
		public int HourlyFee { get => hourlyFee; set => hourlyFee = value; }
		public string Certification { get => certification; set => certification = value; }

		public override string ToString()
		{
			return $"{TrainerId}" + base.ToString() + $"{BaseSalary}:{HourlyFee}:{Certification}:{AccountStatus}";
		}
	}
}


