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

		public Gym(int gymID, string street, string city, string province, string postal)
		{
			this.gymID = gymID;
			this.street = street;
			this.city = city;
			this.province = province;
			this.postal = postal;
		}

		public int GymID { get => gymID; set => gymID = value; }
		public string Street { get => street; set => street = value; }
		public string City { get => city; set => city = value; }
		public string Province { get => province; set => province = value; }
		public string Postal { get => postal; set => postal = value; }

		public override string ToString()
		{
			return $"{GymID}" + base.ToString() + $"{Street}:{City}:{Province}:{Postal}";
		}
	}
}
