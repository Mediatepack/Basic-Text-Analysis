///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  TextAnalysis/Text Analysis
//	File Name:         DistinctWord.cs
//	Description:       Will be used to break down each word that is in the text file a user will use in the program.
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Ethan Morgan, morganer@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Thursday, February 18, 2021
//	Copyright:         Ethan Morgan, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

namespace Text_Analysis
{
    /// <summary>
    /// Will be the class for showing individual words.
    /// </summary>
    class DistinctWord : IEquatable<DistinctWord>, IComparable<DistinctWord>
    {
        /// <summary>
        /// The variable used to hold the word counter to be used in the class
        /// </summary>
        public int wordCounter { get; private set; }

        /// <summary>
        /// This is the variable where words will be stored.
        /// </summary>
        public string word { get; }

        /// <summary>
        /// This is the deffault constructor for the DistinctWord class.
        /// </summary>
        public DistinctWord()
        {
            //These are setting the deffault values for the variables in the deffault DistinctWord constructor.
            this.word = " ";
            this.wordCounter = 0;
        }

        /// <summary>
        /// The parameter Distinctword that will hold the string of a word.
        /// </summary>
        /// <param name="word"></param>
        public DistinctWord(string word)
        {
            this.word = word.ToLower(); //This will make the word passed through lowercase.
            this.wordCounter = 1;
        }

        /// <summary>
        /// This will be used to make the wordCounter go up by one everytime it is called.
        /// </summary>
        public void CountWord()
        {
            wordCounter++;//Will make wordCounter go up by 1.
        }

        /// <summary>
        /// Sees if a DistinctWord is equal to another Distinct word by running it through as a parameter.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(DistinctWord other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;

            return this.word == other.word;
           
        }

        /// <summary>
        /// Checks to see if a sidtinct word is equal to another distinctword.
        /// </summary>
        /// <param name="distinctWord1"></param>
        /// <param name="distinctWord2"></param>
        /// <returns></returns>
        public static bool operator == (DistinctWord distinctWord1, DistinctWord distinctWord2)
            
        {
            return distinctWord1.Equals(distinctWord2);
        }

        /// <summary>
        /// Checks if a distinct word is not equal to another distinctword.
        /// </summary>
        /// <param name="distinctWord1"></param>
        /// <param name="distinctWord2"></param>
        /// <returns></returns>
        public static bool operator != (DistinctWord distinctWord1, DistinctWord distinctWord2)
        {
            return !distinctWord1.Equals(distinctWord2);
        }

        /// <summary>
        /// Checks to see if a Distinctword is equal to a string.
        /// </summary>
        /// <param name="distinct1"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool operator == (DistinctWord distinct1, string t)
        {
            return distinct1.word == t;
        }

        /// <summary>
        /// Checks to see if the Distinct word does not equal a string.
        /// </summary>
        /// <param name="distinct1"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool operator != (DistinctWord distinct1, string t)
        {
            return distinct1.word != t;
        }

        /// <summary>
        /// Compares the Distincts words with eachother to see if they are th esame.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(DistinctWord other)
        {
            if (Object.ReferenceEquals(other, null))
                return 1;
            return this.word.CompareTo(other.word);
        }

        /// <summary>
        /// Will be used to display the words and the amount of times those words appear int he text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string msg = "";

            msg += " " + word.PadRight(25) + wordCounter;//Will use PadRight to put 25 spavces between the words and the amount of times they appeared in the text.

            return msg;
        }
    }
}
