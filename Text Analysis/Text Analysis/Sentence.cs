///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project: TextAnalysis/Text Analysis
//	File Name:         Sentence.cs
//	Description:       Is supposed to represent a single sentence that will be used for processing.
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Ethan Morgan, morganer@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Sunday, February 19, 2021
//	Copyright:         Ethan Morgan, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Linq;


namespace Text_Analysis
{
   /// <summary>
   /// Will be the sentence class for the application for storing the sentences.
   /// </summary>
    class Sentence
    {
        /// <summary>
        /// This will be where the original text for the sentces will be stored.
        /// </summary>
        public string SentenceText { get; set; }

        /// <summary>
        /// This variable will be used to get the number of words.
        /// </summary>
        public int NumberWords { get; private set; }

        /// <summary>
        /// This variable will be used to store the average word length.
        /// </summary>
        public double AverageLength { get; private set; }

        /// <summary>
        /// This variable will be used to mark the first index in the list.
        /// </summary>
        public int FirstSubscipt { get; private set; }

        /// <summary>
        /// Variable for the last index value in a list.
        /// </summary>
        public int LastSubscript { get; private set; }

        /// <summary>
        /// Deffault constructor for Sentence
        /// </summary>
        public Sentence()
        {
            NumberWords = 0;//Sets to a deffault value.

            AverageLength = 0;//Sets to a deffault value.
        }

        /// <summary>
        /// This is the sentence constructor that will be used to take in text objects and break them down into sentence objects for display. 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tokenLocation"></param>
        public Sentence(Text text, int tokenLocation)
        {
            List<string> tokens = text.TextList;

            FirstSubscipt = tokenLocation;//sets the firstSubsript to be equal to the token Location set in the driver class when called.


            for (int i = FirstSubscipt; i < tokens.Count(); i++)
            {
                string t = tokens[i];//lets string t equal the tokens contents.
                if(t == "." | t == "!" | t == "?" | t == @"\n\n" | t == @"\r\r")//Will make sure values in the tokens list are equal to these.
                {
                    LastSubscript = i;//If theyare equal it will set the lastSubscript to one of them ending the current sentnce it is on.
                    break;//this will break out ending the sentnce.
                }
            }

            NumberWords = LastSubscript - FirstSubscipt + 1; 

            for(int i = FirstSubscipt; i <= LastSubscript; i++)
            {
                if (tokens[i] != @"\n\n" & tokens[i] != @"\n" & tokens[i] != @"\r\r")//Will make sure that a value in the tokens lsit does not equal one of these.
                {
                    if (i + 1 <= tokens.Count - 1)//Runs through this for loop.
                    {
                        if (tokens[i + 1] == "." | tokens[i + 1] == "!" | tokens[i + 1] == "?" | tokens[i + 1] == "," | tokens[i + 1] == ";")//checks to see if the value does equal one of these.
                            SentenceText += tokens[i];//if it does will add it to sentenceText without space for propper formating.
                        else
                            SentenceText += tokens[i] + " ";//Else it will add it to Sentence with a space.
                    }
                    else
                        SentenceText += tokens[i];
                }
            }

            //This is for calculating total words in the sentences.
            double totalWords = 0;
            for (int i = FirstSubscipt; i <= LastSubscript; i++)
                totalWords += tokens[i].Length;

            AverageLength = totalWords / (LastSubscript - FirstSubscipt);//Calculations for the AverageLength of the words.
        }

        /// <summary>
        /// This is the override for the ToString that will be used for displaying the Average word length, and number of words per sentence.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string msg = "";

            msg += SentenceText;
            msg += "\n\nAverage Word Length: " + AverageLength + "".PadRight(15);//Will use PadRight to move the text 15 spaces to the right formating it propper.
            msg += "Number of Words: " + NumberWords;

            return msg;
        }
    }
}
