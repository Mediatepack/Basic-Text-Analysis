///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  TextAnalysis/Text Analysis
//	File Name:         User.cs
//	Description:       Will be where a new user is created allowing a user to set their information for the program.
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Ethan Morgan, morganer@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Saturday, February 13, 2021
//	Copyright:         Ethan Morgan, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Text.RegularExpressions;

namespace Text_Analysis
{
    class User
    {
        //These are needed for the driver to get proper input from the user.
        public string name; 
        public string email;
        public string phoneNumber;

        /// <summary>
        /// Deffault constructor for the User class
        /// </summary>
        public User()
        {
            //Sets the vairables to deffault values.
            name = " ";
            email = " ";
            phoneNumber = " ";
        }

        /// <summary>
        /// This will be the User constructor with three parametors, name, email, and phonenumber.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        public User(string name, string email, string phoneNumber)
        {
            //Basic parameter constructor for the user.  Will set their name, email, and phonenumber.
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;

        }

        /// <summary>
        /// this is the variable that will hold the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This is the variable that will hold the email
        /// </summary>
        public string Email
        {
            get => this.email;

            set
            {
               if (CheckUser(value ,@"^\S+@\S+$")) //Regex for the simple email that a user can create.
               {
                 this.email = value;
               }
            }
        }

        /// <summary>
        /// This is the variable that will hold the phonenumber.
        /// </summary>
        public string PhoneNumber
        {
            get => this.phoneNumber;

            set
            {
                if (CheckUser(value, @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$")) //Regex code for a simple phonenumber Ex. (XXX) XXX-XXXX 
                {
                   this.phoneNumber = value;
                }
            }
        }

        /// <summary>
        /// This will be used to check the regex to make sure that the user inputs a propper email and phonenumber
        /// </summary>
        /// <param name="checkedPattern"></param>
        /// <param name="actualPattern"></param>
        /// <returns></returns>
        public bool CheckUser(string checkedPattern, string @actualPattern)
        {
            Regex pattern = new Regex(actualPattern);//Will make a regex witht he pattern put in the setter and the driver.

            Match matches = pattern.Match(checkedPattern.ToLower());//Will use the checkedPattern and make them lower case.

            return matches.Success;

        }

        /// <summary>
        /// This will be used to display the user's information that the user will input in the apllication.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string msg = "";

            msg += "Name:        " + name;
            msg += "\nEmail:       " + email;
            msg += "\nPhoneNumber: " + phoneNumber;

            return msg;

        }

    }
}

