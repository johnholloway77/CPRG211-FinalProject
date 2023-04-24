using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Models
{
    public class Customer: Person
    {
        private int custID;
        private DateTime dateOfBirth;
        private string membershipType;

        public Customer(int custID, string firstName, string lastName, string phoneNumber, string email, DateTime dateOfBirth, string membershipType, bool accountStatus)
        {
            this.CustID = custID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.DateOfBirth = dateOfBirth;
            this.MembershipType = membershipType;
            this.AccountStatus = accountStatus;
        }

        public int CustID { get => custID; set => custID = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string MembershipType { get => membershipType; set => membershipType = value; }

        public override string ToString()
        {
            return $"{CustID}:" +  base.ToString() + $"{DateOfBirth}:{MembershipType}:{AccountStatus}";
        }
    }


}
