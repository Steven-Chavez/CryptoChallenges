﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set1Challenge3_XORCipher
{
    /// <summary>
    /// Author: Steven Chavez
    /// Date: 6/9/17
    /// File: DiscoverSingleCharacterKey.cs
    /// Version: 1.0
    /// 
    /// Discovers the single character key by running 
    /// an array of characters against an XOR'd hex 
    /// encoded string. Each result is scored, displaying 
    /// the top five most likely keys and their messages. 
    /// </summary>
    class DiscoverSingleCharacterKey
    {
        /// <summary>
        /// Contains XOR encoded hex string
        /// </summary>
        private string message;
        /// <summary>
        /// Contains array of hex pairs
        /// </summary>
        private string[] twoDigitHexValueSeperation;
        /// <summary>
        /// Scores each decoded message
        /// </summary>
        private EnglishTextScore score = new EnglishTextScore();
        /// <summary>
        /// Container for scored messages
        /// </summary>
        private ScoredMessage[] scoredMessages = new ScoredMessage[26]; 
        /// <summary>
        /// Contains each letter of the alphabet A-Z
        /// </summary>
        private char[] alphabet = new char[26]
            {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
             'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
             'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
             'Y', 'Z'};

        /// <summary>
        /// Default constructor for DiscoverSingleCharacterKey
        /// class. Takes in message as argument.
        /// </summary>
        /// <param name="message"></param>
        public DiscoverSingleCharacterKey(string message)
        {
            this.message = message;

            //assign values to the array
            for(int i = 0; i < scoredMessages.Length; i++)
            {
                scoredMessages[i] = new ScoredMessage();
            }

            twoDigitHexValueSeperation = separateHexValueIntoPairs(message);
            decipherMsgXOR();
        }

        /// <summary>
        /// Separate hexadecimal string into an array by pairs.
        /// Making the hexadecimal value easy to do work on.
        /// </summary>
        /// <param name="hex">Hexadecimal string to be separated</param>
        /// <returns>Paired hexadecimal array</returns>
        private string[] separateHexValueIntoPairs(string hex)
        {
            string[] hexValueSeperation = new string[hex.Length / 2];
            int index = 0;

            // Separate hex values into pairs.
            for (int i = 0; i < hex.Length; i++)
            {
                // Allows for pulling of pairs from even indices
                if (0 == i % 2)
                {
                    hexValueSeperation[index] = hex.ElementAt(i).ToString()
                        + hex.ElementAt(i + 1).ToString();
                    index++;
                }
            }
            return hexValueSeperation;
        }

        /// <summary>
        /// decipher message using alphabet and XOR logic.
        /// </summary>
        private void decipherMsgXOR()
        {
            string letterRawByte = "";
            int index = 0;

            // Loop through each char in alphabet. 
            foreach(char c in alphabet)
            {
                // Convert char to raw byte.
                letterRawByte = charToRawByte(c);

                // Decode the message by each letter.
                scoredMessages[index] = decodeXORMessage(letterRawByte, c);
                index++;
            }

            foreach(ScoredMessage value in scoredMessages)
            {
                Console.WriteLine(value.ToString());
            }
        }

        /// <summary>
        /// Takes hex value, converts into raw byte for encoding.
        /// </summary>
        /// <param name="hexPair">hexadecimal pair value</param>
        /// <returns>string of raw byte</returns>
        private string hexToRawByte(string hexPair)
        {
            byte conversion = Convert.ToByte(Convert.ToInt32(hexPair, 16));
            string rawByte = Convert.ToString(conversion, 2);
            
            // Ensure raw byte string is 8 character in length
            if (rawByte.Length < 8)
            {
                rawByte = rawByte.PadLeft(8, '0');
            }

            return rawByte;
        }

        /// <summary>
        /// Takes char value and converts into raw byte for encoding.
        /// </summary>
        /// <param name="letter">Char to be converted</param>
        /// <returns>String of raw byte</returns>
        private string charToRawByte(char letter)
        {
            // Convert letter to int
            int test = Convert.ToInt32(letter);
            // Convert int to hex
            string hex = String.Format("{0:X}", test);
            // Convert hex value to raw byte and return
            return hexToRawByte(hex);
        }

        private ScoredMessage decodeXORMessage(string letterRawByte, char key)
        {
            
        }
    }
}
