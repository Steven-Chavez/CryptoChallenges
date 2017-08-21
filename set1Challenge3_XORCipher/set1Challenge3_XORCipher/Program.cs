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
    /// File: Program.cs
    /// 
    /// Set 1 challenge 3 of the crypto challenges.
    /// http://cryptopals.com/sets/1/challenges/3
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string test = "Scores a piece of English plain text. Used to score how successful a decrypted message was. " +
                          "The method used to score the English plain text is done by character frequency.";
            EnglishTextScore score = new EnglishTextScore(test);
        }
    }
}
