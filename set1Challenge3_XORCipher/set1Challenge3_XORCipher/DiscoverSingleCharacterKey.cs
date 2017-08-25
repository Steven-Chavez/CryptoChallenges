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
        /// Default constructor for DiscoverSingleCharacterKey
        /// class. Takes in message as argument.
        /// </summary>
        /// <param name="message"></param>
        public DiscoverSingleCharacterKey(string message)
        {
            this.message = message;
            twoDigitHexValueSeperation = separateHexValueIntoPairs(message);
            decipherMsgXOR();
        }

        // loop
        // run one character (97-122) against encoded string at a time
        // decode using raw bytes
        // score decoded message
        // Display top five

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
        /// decipher message using alphabet and XOR logic
        /// </summary>
        private void decipherMsgXOR()
        {
            byte[] conversion = new byte[twoDigitHexValueSeperation.Length];
            
            foreach(string value in twoDigitHexValueSeperation)
            {

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
            return rawByte;
        }
    }
}
