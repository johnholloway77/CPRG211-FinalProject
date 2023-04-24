using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Models
{
	public class Equipment
	{
		private int equipmentId;
		private int gymID;
		private string equipmenttype;
		private byte weightLBS;

		public Equipment(int equipmentId, int gymID, string equipmenttype, byte weightLBS)
		{
			this.equipmentId = equipmentId;
			this.gymID = gymID;
			this.equipmenttype = equipmenttype;
			this.weightLBS = weightLBS;
		}

		public int EquipmentId { get => equipmentId; set => equipmentId = value; }
		public int GymID { get => gymID; set => gymID = value; }
		public string Equipmenttype { get => equipmenttype; set => equipmenttype = value; }
		public byte WeightLBS { get => weightLBS; set => weightLBS = value; }

		public override string ToString()
		{
			return $"{EquipmentId}" + base.ToString() + $"{GymID}:{Equipmenttype}:{WeightLBS}";
		}
	}
}
