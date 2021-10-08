///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Textanalysis/Text Analysis
//	File Name:         Utility.cs
//	Description:       This is where methods that will help the program overall will be stored
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Ethan Morgan, morganer@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Friday, February 12, 2021
//	Copyright:         Ethan Morgan, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Text_Analysis
{
    class Utility
    {
       //Change this some to make look better/different. Also fix it 
       /// <summary>
       /// This will cut up the words in the text file into tokens to help the application overall.
       /// </summary>
       /// <param name="original"></param>
       /// <param name="delimiters"></param>
       /// <returns></returns>
        public static List<String> Tokenize(string original, string delimiters)
        {
            char[] dChars = delimiters.ToCharArray();

            string cleanLine = Clean(ref original);
            List<string> tokens = new List<string>();
            int beggining = 0;
            int ending = 0;

            while (beggining < cleanLine.Length)
            {
                //will seperate the words and punctuations using the Clean method.
                ending = cleanLine.IndexOfAny(dChars, beggining);

                if (beggining < ending)//checks if beggining is less than ending.
                {
                    tokens.Add(cleanLine.Substring(beggining, ending - beggining + 1).Trim());
                }
                else if (beggining == ending)//checks if begging is equal to ending.
                {
                    tokens.Add(cleanLine.Substring(beggining, 1).Trim());
                }
                else if (ending == -1)//checks endnig.
                {
                    tokens.Add(cleanLine.Substring(beggining, cleanLine.Length - beggining).Trim());
                    ending = cleanLine.Length;
                }

                beggining = ending + 1;
            }

            return tokens;//returns the tokens.
        }

        /// <summary>
        /// This will hlep seperate puctuations from words.
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        public static string Clean(ref string work)
        {
            string pattern = @"(\\n\\n|\\r\\r|[^a-zA-Z_ 0-9'])"; //Regex code to seperate the punctuations from everything else.
            Regex filter = new Regex(pattern);

            MatchEvaluator evaluator = new MatchEvaluator(CleanUp);
            string cleaned = filter.Replace(work, evaluator);
            cleaned = Regex.Replace(cleaned, @"\s+", " ");

            return cleaned;
        }

        /// <summary>
        /// This will help the clean method function.
        /// </summary>
        /// <param name="cleanMatch"></param>
        /// <returns></returns>
        private static string CleanUp(Match cleanMatch)
        {
            string msg = cleanMatch.Value;//Will set the string msg equal to the cleanMatch value.

            msg = " " + msg + " ";

            return msg;
        }//end of CleanUp

        /// <summary>
        /// This will allow the user to actaully select a file.
        /// </summary>
        /// <returns></returns>
        public static string OpenFile_Click()
        {
            string fileContent = string.Empty;//will set the string fileContent to an empty string.

            OpenFileDialog dlg = new OpenFileDialog();//makes a OpenFileDialgo named dlg.
            dlg.InitialDirectory = Application.StartupPath;//makes the Directory the starting path for the user to make it to where they can go around getting text files.
            dlg.Title = "Open a personal Library";
            dlg.Filter = "text files|*.txt|all files|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)//if the user selects a file and selects ok it will set the filecontent to the file they selected.
            {
                fileContent = dlg.FileName;
            }
            return fileContent;//returns the filecontent.
        }//end of OpenFile_Click
    }//end of Utility
}
