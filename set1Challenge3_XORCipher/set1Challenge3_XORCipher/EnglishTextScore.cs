using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set1Challenge3_XORCipher
{
    /// <summary>
    /// Author: Steven Chavez
    /// Date: 4/27/2017
    /// File: EnglishTextScore.cs
    /// Version: 1.0
    /// 
    /// Scores a piece of English plain text. Used to 
    /// score how successful a decrypted message was. 
    /// The method used to score the English plain text 
    /// is done by character frequency.
    /// </summary>
    class EnglishTextScore
    {
        /// <summary>
        /// Total characters in string. Used for percentage 
        /// purposes.
        /// </summary>
        private int charTotal;

        /// <summary>
        /// Contains message to be scored.
        /// </summary>
        private string message;

        /// <summary>
        /// Contains each letter of the alphabet A-Z
        /// </summary>
        private string[] alphabet = new string[26]
            {"A", "B", "C", "D", "E", "F", "G", "H",
             "I", "J", "K", "L", "M", "N", "O", "P",
             "Q", "R", "S", "T", "U", "V", "W", "X",
             "Y", "Z"};

        /// <summary>
        /// Contains each character frequency. In order
        /// of the alphabet A-Z.
        /// </summary>
        private double[] frequency = new double[26]
            {8.12, 1.49, 2.71, 4.32, 12.02, 2.30, 2.03,
             5.92, 7.31, 0.10, 0.69, 3.98, 2.61, 6.95,
             7.68, 1.82, 0.11, 6.02, 6.28, 9.10, 2.88,
             1.11, 2.09, 0.17, 2.11, 0.07};

        /// <summary>
        /// Contains the count of each char in message. 
        /// Array corresponds with alphabet array. If 
        /// alphabet[0] = 5 then there are 5 A's.  
        /// </summary>
        private int[] charCount = new int[26];

        /// <summary>
        /// Default constructor for EnglishTextScore 
        /// class. Takes in message as argument.
        /// </summary>
        /// <param name="message">string</param>
        public EnglishTextScore(string message)
        {
            this.message = message;
            messageDissect();
        }


        private void messageDissect()
        {
            // Convert message to char array and sort array
            // in order to make char counting more efficient.
            char[] charArray = message.ToCharArray();
            Array.Sort(charArray);
            
            
        }
    }
}
