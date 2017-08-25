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
    /// score how successful a decrypted message is. 
    /// The method used to score the English plain text 
    /// is done by character frequency. Lowest score out
    /// of pool of decrypted messages is most likely to 
    /// be the successful decryption.
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
        /// Contains score. Lowest score out of pool of
        /// messages is most likely to be a successful
        /// decryption. 
        /// </summary>
        private double score;

        /// <summary>
        /// Contains each letter of the alphabet A-Z
        /// </summary>
        private char[] alphabet = new char[26]
            {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
             'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
             'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
             'Y', 'Z'};

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
        /// Holds the frequency of characters in message
        /// to be tested against the English character 
        /// frequency. 
        /// </summary>
        private double[] msgFrequency = new double[26];

        /// <summary>
        /// Contains message split into chars.
        /// </summary>
        private char[] messageSplit;

        /// <summary>
        /// Default constructor for EnglishTextScore 
        /// class
        /// </summary>
        public EnglishTextScore()
        {
            this.message = "";
        }

        /// <summary>
        /// Overloaded constructor for EnglishTextScore 
        /// class. Takes in message as argument.
        /// </summary>
        /// <param name="message">string</param>
        public EnglishTextScore(string message)
        {
            this.message = message;
            
            // Call appropriate methods
            messageSort();
            charCounter();
            messageFrequency();
            scoreMessage();
        }

        /// <summary>
        /// Get score of messages likeliness of being
        /// a successful decrypt. 
        /// </summary>
        /// <returns>double</returns>
        public double getScore()
        {
            return score;
        }

        /// <summary>
        /// score message
        /// </summary>
        /// <param name="message">message</param>
        public void scoreMessage(string message)
        {
            this.message = message;

            // Call appropriate methods
            messageSort();
            charCounter();
            messageFrequency();
            scoreMessage();
        }

        /// <summary>
        /// Separates message into char array and sorts
        /// array in alphabetical order. 
        /// </summary>
        private void messageSort()
        {
            string tempMessage = "";

            // Remove spaces in string.
            tempMessage = message.Replace(" ", "");

            tempMessage = tempMessage.Replace(".", "");

            // Get length of message without spaces.
            charTotal = tempMessage.Length;

            // Convert all letters to uppercase.
            tempMessage = tempMessage.ToUpper();

            // Convert message to char array and sort array
            // in order to make char counting more efficient.
            messageSplit = tempMessage.ToCharArray();
            Array.Sort(messageSplit);
        }

        /// <summary>
        /// Takes a count of each character in message.
        /// </summary>
        private void charCounter()
        {
            int index = 0;

            // Loop through each char in message.
            for(int i = 0; i < charTotal; i++)
            {
                bool found = true;

                // Must test every char against alphabet
                // until a match is found.
                while (found == true)
                {
                    if(messageSplit[i] == alphabet[index])
                    {
                        charCount[index]++;
                        found = false;
                    }
                    else
                    {
                        index++;
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the frequency of each character in message.
        /// </summary>
        private void messageFrequency()
        {
            for(int i = 0; i < charCount.Length; i++)
            {
                msgFrequency[i] = (charCount[i] / (double)charTotal) * 100;
                msgFrequency[i] = Math.Round(msgFrequency[i], 2);
            }
        }

        /// <summary>
        /// scores message by acquiring the average of the difference 
        /// between the two frequencies. 
        /// </summary>
        private void scoreMessage()
        {
            double[] difference = new double[26];

            for (int i = 0; i < difference.Length; i++)
            {
                difference[i] = Math.Abs(frequency[i] - msgFrequency[i]);
            }

            score = difference.Average();
        }
    }
}
