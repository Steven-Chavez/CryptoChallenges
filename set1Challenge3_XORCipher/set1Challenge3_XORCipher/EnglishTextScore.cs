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
        /// Total letters in string. Used for percentage 
        /// purposes.
        /// </summary>
        int letterTotal;

        /// <summary>
        /// Contains each letter of the alphabet along 
        /// with the percentage of the frequency that 
        /// they are found in the English language.
        /// </summary>
        string[] alphabet = new string[26]
            {"A", "B", "C", "D", "E", "F", "G", "H",
             "I", "J", "K", "L", "M", "N", "O", "P",
             "Q", "R", "S", "T", "U", "V", "W", "X",
             "Y", "Z"};

    }
}
