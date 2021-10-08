///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  TextAnalysis/Text Analysis
//	File Name:         Words.cs
//	Description:       Will be used to store all the distinct words in a list that will be used by the user.
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Ethan Morgan, morganer@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Thursday, February 18, 2021
//	Copyright:         Ethan Morgan, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Linq;

namespace Text_Analysis
{
    /// <summary>
    /// Used to store the distinctWord objects.
    /// </summary>
    class Words
    {
        /// <summary>
        /// This wi;; be the list where the Distinct words will be put into.
        /// </summary>
        public List<DistinctWord> WordList { get; private set; }

        /// <summary>
        /// This variable will be used to hold the count of words that are in the file.
        /// </summary>
        public int Count { get; }
        
        /// <summary>
        /// The deffault consctructor for the Word class.
        /// </summary>
        public Words()
        {
            //Deffault values for the variables.
            WordList = new List<DistinctWord>();

            Count = 0;
        }

        /// <summary>
        /// Paramter Words constructor that will take text from the file in the form of Distinct words and give information off of them.
        /// </summary>
        /// <param name="textObject"></param>
        public Words(Text textObject)
        {
            WordList = new List<DistinctWord>();//Creates a WordList that will hold Distinct Words.

            List<string> tokens = textObject.TextList;//Creats a tokens list that will hold the tokens.

                //This will run a loop for tokeens that will take the tokens and add them to a list of the DistinctWords.
                foreach (string t in tokens)
                {
                    if (WordList.Count() == 0)//This will be needed to not go out of bounds at the start.
                    {
                         WordList.Add(new DistinctWord(tokens[0]));
                    }
                    else
                    {
                        for (int i = 0; i <= WordList.Count() - 1; i++)
                        {
                            DistinctWord distinctWord = WordList[i];
                            if (distinctWord == t.ToLower())
                            {
                                WordList[i].CountWord();
                                i = WordList.Count();
                            }
                            else if (distinctWord != t.ToLower() && i == WordList.Count() - 1)
                            {
                                WordList.Add(new DistinctWord(t));
                                i++;
                            }
                        }
                    }
                }

                this.Count = WordList.Count();//makes the count equal to the WordList Count.

            SortList();//Will sort the words.

        }

        /// <summary>
        /// This will sort the list of words in alphabetical order.
        /// </summary>
        public void SortList()
        {
            WordList.Sort();//This will sort the list based off of alphabetical order.
        }

        /// <summary>
        /// This will display the information to the user about the words in the text file that they selected.
        /// </summary>
        /// <returns></returns>
        public string DisplayWords()
        {
            string msg = "";
            int t = 1;
            foreach (DistinctWord dw in WordList)
            {
                if (t <= 9)
                    msg += " " + t + ": " + dw.ToString() + "\n";
                else if (t > 9)
                    msg += t + ": " + dw.ToString() + "\n";
                t++;
            }
            return msg;
        }
    }
}
