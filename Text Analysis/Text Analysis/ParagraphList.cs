///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  TextAnalysis/Text Analysis
//	File Name:         ParagraphList.cs
//	Description:       This is to hold the paragraphs in the paragraph list from the file the user put in.
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Ethan Morgan, Morganer@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Monday, February 22, 2021
//	Copyright:         Ethan Morgan, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Linq;

namespace Text_Analysis
{
    /// <summary>
    /// Will be the container for the paragraph objects.
    /// </summary>
    class ParagraphList
    {
        /// <summary>
        /// The List that will hold the paragraph objects.
        /// </summary>
        public List<Paragraph> PList { get; private set; }

        /// <summary>
        /// The variable that will hold the number of paragraphs.
        /// </summary>
        public int NumberOfParagraphs { get; private set; }

        /// <summary>
        /// The variable that will be used to hold the Average Number of words in the paragraph.
        /// </summary>
        public double AverageNumberWords { get; private set; }

        /// <summary>
        /// Deffault constructor for ParagraphList
        /// </summary>
        public ParagraphList()
        {
            PList = new List<Paragraph>();
            NumberOfParagraphs = 0;//Sets deffault value.
            AverageNumberWords = 0;//Sets deffault value.
        }

        /// <summary>
        /// Parameter Paragraph constructor that will take paragraph objects from text objects and allow the user to see the disired displays.
        /// </summary>
        /// <param name="text"></param>
        public ParagraphList(Text text)
        {
            PList = new List<Paragraph>();//Will establish the PList of paragraph objects.

            int startPosition = 0;
            int i = 0;

            while (startPosition < text.TextList.Count())
            {

                PList.Add(new Paragraph(text, startPosition));//will add paragraph objects to th elist while in the while loop.
                startPosition = PList[i].EndingSubscript + 1;
                i++;//Makes i go up by 1 each time it is ran through.

            }

            NumberOfParagraphs = PList.Count;//Sets numberOfParagraphs to the PList count.

            double e = 0;//Need a double here 
            foreach (Paragraph t in PList)
            {
                e += t.NumW;
            }

            AverageNumberWords = e / PList.Count;//AverageNumberWords will be equal to the e (The  double for all the words) and will divede e by the PList Count.
        }

        /// <summary>
        /// This will be used to display all of the information to the user.
        /// </summary>
        /// <returns></returns>
        public string DisplayParagrahList()
        {
            string msg = "";//will set a empty msg string.
            int c = 1;//sets int c at 1.

            msg += "Paragraphs found in text:";

            foreach(Paragraph p in PList)
            {
                msg += "\n\nParagraph " + c++;//will increase c by 1 everytime it is ran through the loop.
                msg += "\n\n" + p.ToString();
            }
            msg += "\n\nThere are " + NumberOfParagraphs + " paragraphs.  " + "The average words in the paragraphs is " + AverageNumberWords;

            return msg;
        }

    }
}
