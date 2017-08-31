using System;
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
        /// Raw bytes of the hex pairs from the message.
        /// </summary>
        private string[] rawByteHexPair;
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
            decodeXORMessage();
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
        private void decodeXORMessage()
        {
            rawByteHexPair = new string[twoDigitHexValueSeperation.Length];
            string letterRawByte = "";
            int index = 0;

            // Get raw byte of each hex pair
            for(int i = 0; i < rawByteHexPair.Length; i++)
            {
                rawByteHexPair[i] = hexToRawByte(twoDigitHexValueSeperation[i]);
            } 

            // Loop through each char in alphabet. 
            foreach(char c in alphabet)
            {
                // Convert char to raw byte.
                letterRawByte = charToRawByte(c);

                // Decode the message by each letter.
                scoredMessages[index] = decodeXORCalc(letterRawByte, c);
                index++;
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

        /// <summary>
        /// Decodes the XOR'd hex string against each letter in the
        /// alphabet. 
        /// </summary>
        /// <param name="letterRawByte">Raw byte representation of letter</param>
        /// <param name="key">char representation of letter</param>
        /// <returns>Scored Message object with decoded data</returns>
        private ScoredMessage decodeXORCalc(string letterRawByte, char key)
        {
            //Local variables
            string[] decodedByte = new string[rawByteHexPair.Length];
            string decodedMessage = "";
            ScoredMessage sMsg = new ScoredMessage();

            // loop through each hexPair and decode message with single
            // char from alphabet.
            for (int i = 0; i < rawByteHexPair.Length; i++)
            {
                int decodedDecimal = 0;

                for (int j = 0; j < 8; j++)
                {
                    // If the encoded bit is 1 the decoded bit is the opposite
                    // of the letter bit. 
                    if (rawByteHexPair[i].ElementAt(j) == '1')
                    {
                        if (letterRawByte.ElementAt(j) == '1')
                        {
                            decodedByte[i] += "0";
                        }
                        else
                        {
                            decodedByte[i] += "1";
                        }
                    }
                    // If the encoded bit is 0 the decoded bit is the same as
                    // the letter bit.
                    else
                    {
                        decodedByte[i] += letterRawByte.ElementAt(j);
                    }
                }

                // Convert decoded byte to string and add to decoded message.
                decodedDecimal = Convert.ToInt32((decodedByte[i]), 2);
                decodedMessage += Convert.ToChar(decodedDecimal);
            }

            // Populate ScoredMessage obj
            sMsg.Message = decodedMessage;
            sMsg.Score = score.scoreMessage(decodedMessage);
            sMsg.Key = key;

            return sMsg;
        }
    }
}
