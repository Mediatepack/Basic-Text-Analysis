///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  TextAnalysis/Text Analysis
//	File Name:         Paragraph.cs
//	Description:       Is supposed to be used to represent a single paragraph
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Ethan Morgan, morganer@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Monday, February 20, 2021
//	Copyright:         Ethan Morgan, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Linq;


namespace Text_Analysis
{
    /// <summary>
    /// Used to stroe the individual paragraph objects and to identify what a paragraph is.
    /// </summary>
    class Paragraph
    {
        /// <summary>
        /// This is a variable that will hold all of the paragraph text.
        /// </summary>
        public string ParagraphText { get; private set; }

        /// <summary>
        /// number of sentences variable.
        /// </summary>
        public int Nos { get; private set; }

        /// <summary>
        /// number of words variable.
        /// </summary>
        public int NumW { get; private set; }

        /// <summary>
        /// Average sentence varibale.
        /// </summary>
        public double AverageS { get; private set; }

        /// <summary>
        /// The starting point in the index fo rthe list.
        /// </summary>
        public int StartingSubscript { get; private set; }


        /// <summary>
        /// The last point in the index
        /// </summary>
        public int EndingSubscript { get; private set; } 


        /// <summary>
        /// Deffault constructor for the Paragraph class.
        /// </summary>
        public Paragraph()
        {
            //Will set the deffault values.
            AverageS = 0;
            NumW = 0;
            Nos = 0;
            ParagraphText = " ";
            
        }

        /// <summary>
        /// Paragraph's paramter constructor that will take in text and a sentence location to identify a paragraph in a txt file.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sentenceLocation"></param>
        public Paragraph(Text text, int sentenceLocation)
       {
            List<string> tokens = text.TextList;
            StartingSubscript = sentenceLocation;

            //Runs through a loop that will be used to check for /n/n /n /r/r that identifies a new paragraph
            for(int i = sentenceLocation; i < tokens.Count(); i++)
            {
                string t = tokens[i];
                if (t == @"\n\n" | t == @"\n" | t == @"\r\r")
                {
                    EndingSubscript = i;
                    break;
                }
            }

            //Runs through the loop checking for end punctuations in the paragraphs.
            for (int i = StartingSubscript; i < EndingSubscript; i++)
            {
                if (i + 1 <= tokens.Count - 1)
                {
                    if (tokens[i + 1] == "." | tokens[i + 1] == "!" | tokens[i + 1] == "?" | tokens[i + 1] == "," | tokens[i + 1] == ";")
                        ParagraphText += tokens[i];
                    else
                        ParagraphText += tokens[i] + " ";
                }
                else
                    ParagraphText += tokens[i];
                NumW++;
            }
            NumW = EndingSubscript - StartingSubscript + 1;
            SentenceList sentenceList = new SentenceList(text, EndingSubscript, StartingSubscript);
            Nos = sentenceList.Nos;

            AverageS = sentenceList.AverageSLength;
        }

        /// <summary>
        /// The overriden ToString that will be used in ParagraphList to help display information to the user.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string msg = "";

            
            msg += ParagraphText;
            msg += "\n\nTotal Sentence: " + Nos + "".PadRight(25);
            msg += "Average Words Per Sentence: " + AverageS;

            return msg;
         }
    }
}
