using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private bool accountStatus;
        protected bool personInitialized;
        private bool accountStatusChanged;

        public string FirstName { get => firstName; set => firstName = value; }
        public bool AccountStatus 
        { 
            get => accountStatus;
            set
            {
                accountStatus = value;
                OnAccountStatusChanged();
            }
        }


        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public bool AccountStatusChanged { get => accountStatusChanged; set => accountStatusChanged = value; }


        //this will trigger when account status changes
        protected abstract void OnAccountStatusChanged();
        


        public override string ToString()
        {
            return $"{FirstName}:{LastName}:{PhoneNumber}:{Email}";
        }
    }
}
