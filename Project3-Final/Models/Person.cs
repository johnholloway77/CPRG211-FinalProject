using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Models
{
    public abstract class Person
    {

        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string email;

        bool accountStatus;

        public string FirstName { get => firstName; set => firstName = value; }
        public bool AccountStatus { get => accountStatus; set => accountStatus = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }

        public override string ToString()
        {
            return $"{FirstName}:{LastName}:{PhoneNumber}:{Email}";
        }
    }
}
