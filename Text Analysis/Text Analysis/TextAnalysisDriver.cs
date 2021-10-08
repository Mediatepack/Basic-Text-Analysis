///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Text_Analysis/Text Analysis
//	File Name:         TextAnalysisDriver.cs
//	Description:       Where all user interaction will be performed and is where the main method is located at allowing the program to be ran.
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Ethan Morgan, Morganer@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Wednesday, February 17, 2021
//	Copyright:         Ethan Morgan, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

namespace Text_Analysis
{
    /// <summary>
    /// This will be the driver fopr the application and will be used to run the program.
    /// </summary>
    class TextAnalysisDriver 
    {
        /// <summary>
        /// The Main method that will ne used to run the application.
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        public static void Main(string[] args)
        {
            StartUp();//Calls to start the program.
        }

        /// <summary>
        /// This Method will be used for creating the menu and for allowing the user to have inputs and outputs.
        /// </summary>
        private static void StartUp()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Title = "Text Analysis Demo Application";

            User newUser = new User();
            bool starting = true;

            while (starting)//Will run through a while loop to make sure the user will correctly input the propper format for their information.
            {
                if (newUser.name == " ")
                {
                    Console.WriteLine("Welcome!");
                    Console.WriteLine("\nWhat is your name?");//Will ask for the user's name and set the user's name to what they inputted.
                    string name = Console.ReadLine();
                    newUser.name = name;
                }

                if (newUser.email == " ")
                {
                    Console.WriteLine("What is your email " + newUser.name + "?");
                    string email = Console.ReadLine();
                    if (newUser.CheckUser(email, @"^\S+@\S+$"))//Checks that the user puts the coreect email with the @ symbol.
                        newUser.email = email;//Sets the email.
                }

                if (newUser.phoneNumber == " ")
                {
                    Console.WriteLine("What is your phonenumber " + newUser.name + "?");
                    string phone = Console.ReadLine();
                    if(newUser.CheckUser(phone, @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"))//Checks that user input is in porpper format if not it will ask it again.
                    newUser.phoneNumber = phone;//sets the phonenumber.
                    starting = false;//will break out of while loop.
                }
                else
                    Console.WriteLine("There was an error in either email or phonenumber please try again");//Will throw them this line if a problem was detected.
            }
            Console.WriteLine("Thank you " + newUser.name + " Please press Enter to select a file to begin the program");
            Console.ReadKey();
            Text newText = new Text(Utility.OpenFile_Click(), " ");


            Menu menu = new Menu(newUser.name + "'s" + " Menu");

            menu = menu + "Get Words in file" + "Get Sentences in file" + "Get Paragraphs in file" + "Exit";

            Choices choice = (Choices)menu.GetChoice();
            while (choice != Choices.QUIT)
            {
                switch (choice)
                {
                   
                    case Choices.GETWORDS:
                        Console.WriteLine("You selected get words form file"); //Will tell the user they selected to view all the words in the text file.
                        Words newWord = new Words(newText);
                        Console.WriteLine(newWord.DisplayWords());
                        Console.ReadKey();
                        break;

                    case Choices.GETSENTENCES:
                        Console.WriteLine("You selected get sentences from file"); //Will tell the user that they selected to view the sentences from the file.
                        SentenceList sl = new SentenceList(newText);
                        Console.WriteLine(sl.SentenceDisplay());
                        Console.ReadKey();
                        break;

                    case Choices.GETPARAGRAPH:
                        Console.WriteLine("You selected get paragraphs from file"); //Will tell the user that they chose to display the paragraphs in the text file.
                        ParagraphList pl = new ParagraphList(newText);
                        Console.WriteLine(pl.DisplayParagrahList());
                        Console.ReadKey();
                        break;

                    case Choices.QUIT:
                        Console.WriteLine("You selected Exit");//Will exit the program.
                        Console.ReadKey();
                        break;

                    
                }  // end of switch

                choice = (Choices)menu.GetChoice();
               
            }  // end of while

            Console.WriteLine("Thank you for using this application!\n" + newUser.ToString()); //Displays the user ToString which will contain the information that the user put in at the start of the program.
            Console.WriteLine("\nPress AnyKey to exit!");//Informs the user that they can press any key to exit the application.
            Console.ReadKey();
        }  
    }
}
