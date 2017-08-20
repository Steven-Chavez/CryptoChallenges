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
        /// Default constructor for DiscoverSingleCharacterKey
        /// class. Takes in message as argument.
        /// </summary>
        /// <param name="message"></param>
        public DiscoverSingleCharacterKey(string message)
        {
            this.message = message;
        }
        // loop
        // run one character (97-122) against encoded string at a time
        // decode using raw bytes
        // score decoded message
        // Display top five


    }
}
