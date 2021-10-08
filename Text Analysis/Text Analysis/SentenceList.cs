///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  TextAnalysis/Text Analysis
//	File Name:         SentenceList.cs
//	Description:       Is used to store all of the sentences in a sentence list that will be used for display and for user actions.
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
    /// Will be used as a container to store all the Sentence objects.
    /// </summary>
    class SentenceList
    {
        /// <summary>
        /// This wil be used to store the sentence objects that will be used for processing.
        /// </summary>
        public List<Sentence> SList { get; private set; }

        /// <summary>
        /// This variable will be used to represent number of sentences
        /// </summary>
        public int Nos { get; private set; }

        /// <summary>
        /// Used ti represent the Average sentence length
        /// </summary>
        public double AverageSLength { get; private set; }

        /// <summary>
        /// The deffault constructor for sentinceList
        /// </summary>
        public SentenceList()
        {
            SList = new List<Sentence>();

            int Nos = 0;//Sets the deffault value for number of words.
            double AverageSLength = 0.00;//Will set the deffault value for AverageSLength.
        }

        /// <summary>
        /// The parameter constructor for SentenceList that will take a text object and store the Sentence objects in the text in a sentence list and will be used for display.
        /// </summary>
        /// <param name="text"></param>
        public SentenceList(Text text)
        {
            SList = new List<Sentence>();//Will create a new SList that will hold Sentnec objects.

            int startingPosition = 0;
            int i = 0;

            while(startingPosition < text.TextList.Count())
            {
                SList.Add(new Sentence(text, startingPosition));//Will add the sentnces to the sentence list.
                startingPosition = SList[i].LastSubscript + 1;

                
                if (SList[i].SentenceText == null)//Make sure that their is not a blank space in the list EX: /n/n /n /r/r.
                {
                    SList.RemoveAt(i);//if there is it will remove it at that index making variable i minus 1.
                    i--;
                }
                i++;//if it is a normal word it will incease i by 1.
            }
            Nos = SList.Count;

            //The below code will go through the List getting the number of words and setting it to the variable d.  This will be uesed to calculate AverageSLength.
            double d = 0;
            foreach (Sentence t in SList)
            {
                d += t.NumberWords;
            }

            AverageSLength = d / Nos;
        }

        /// <summary>
        /// The second paramter constructor for sentenceList that will be used to mark starting and ending points of index's for paragraphs/sentences.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ending"></param>
        /// <param name="starting"></param>
        public SentenceList(Text text, int ending, int starting)
        {

            //This is all the same as the second constructor but its purpose is to grab the starting and ending indexes for the paraghraphs class.  This will be used to make sure that it is a paragraph that is in the list.
            SList = new List<Sentence>();

            int startingPosition = starting;
            int i = 0;

            while (startingPosition <= ending)
            {

                SList.Add(new Sentence(text, startingPosition));
                startingPosition = SList[i].LastSubscript + 1;

                i++;

            }
            Nos = SList.Count;

            double dw = 0;
            foreach (Sentence t in SList)
            {
                dw += t.NumberWords;
            }

            AverageSLength = dw / Nos;
        }

        /// <summary>
        /// The Display method that will be used in the main method that will be used to display the information to the users.
        /// </summary>
        /// <returns></returns>
        public string SentenceDisplay()
        {
            string msg = "";
            int c = 1;

            msg += "Sentence found in text:";

            foreach (Sentence t in SList)
            {
                msg += "\n\nSentence " + c++;
                msg += "\n" + t.ToString();
            }
            return msg;
        }
    }
}
