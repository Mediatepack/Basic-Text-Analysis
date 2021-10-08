///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  TextAnalysis/Text Analysis
//	File Name:         Text.cs
//	Description:       Is supposed to be used to store the file path and the text that will be used in the program.
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Ethan Morgan, morganer@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Monday, February 15, 2021
//	Copyright:         Ethan Morgan, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.IO;


namespace Text_Analysis
{
    /// <summary>
    /// Used to store the Text that that will be in the text file.
    /// </summary>
    class Text
    {
        /// <summary>
        /// The variable to hold the filepath.
        /// </summary>
        public string filePath { get; set; }

        /// <summary>
        /// This variable will hold the content of the file.
        /// </summary>
        public string fileContent { get; set; }

        /// <summary>
        /// The List that will hold the strings of the contents of the file.
        /// </summary>
        public List<string> TextList;

        /// <summary>
        /// Deffault Text class constructor
        /// </summary>
        public Text()
        {
            //Used to set the deffault values for the variables.
            filePath = "";
            fileContent = "";

        }

        /// <summary>
        /// Parameter Text constructor that will take the file path and will set the delimeters.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dell"></param>
        public Text(string path, string dell)
        {
            filePath = path;//sets the filePath to the path.

            //Will use streamReader to read the text in the text files.
            using (StreamReader rdr = new StreamReader(path))
            {
                string line;
                while ((line = rdr.ReadLine()) != null)
                    fileContent += line + "\\n\\n";
            }

            TextList = Utility.Tokenize((fileContent), dell);//Will tokenize the text in the file.
        }

        /// <summary>
        /// Displays the tokenized version of the list of strings.
        /// </summary>
        /// <returns></returns>
        public string DisplayTokens()
        {
            string test = "";

            foreach (string tokens in TextList)
            {
                test += "\n" + tokens;
            }

            return test;
        }

        /// <summary>
        /// Will display the original text from the file.
        /// </summary>
        /// <returns></returns>
        public String DisplayOriginal()
        {
            string originalText = "";

            foreach (string original in TextList)
            {
                originalText += " " + original;
            }
            return originalText;
        }
        
    }
}
