/*
File for abstract class Person

This abstract method is used as a blue print for the other people objects: Customer, Staff, and Trainer.
It contains basic properties and methods common to all people type objects
 
Additionally, it contains the abstract method OnAccountStatusChanged()
This method is used by the child classes to see if the active/inactive status is changed. Methods will use this bool to run additional methods scanning if a person has been set to inactive while having active personal training sessions. 

 */

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

        //personInitialized will be by defaul false, but set to true AFTER the object is first initialized and accountStatus is set 
        protected bool personInitialized; 

        //This bool is set to true when accountStatus is set only AFTER the object is first initialized.  
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
