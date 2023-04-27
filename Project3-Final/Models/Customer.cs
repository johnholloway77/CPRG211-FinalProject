/*
 * File for object Customer
 * 
 * Customers inherit from object Person and use some of the fields and methods within. 
 * 
 * This method contains basic fields,such as custID (the primary key for the Customer table in the MySQL database), as well as other inforamtion such as date of birth, memberhsip type, etc.
 * 
 * Date: 27 April 2023
 * By: John Holloway
 */


using Project3_Final.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

        /*
        The method  OnAccountStatusChanged() is use to detect if accountStatus changes its value. It contains a if statement to check the variable personInitialized is true. The variable personInitialized is initially set to false when object is created. The first time the method is run this variable will be set to true, allowing the method AccountStatusChanged() to run the second time it is invoked.
        This is to prevent the application from checking if the object has any active personal training sessions when it is created..
        */
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
