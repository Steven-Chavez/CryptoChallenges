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
            // Variables
            string hexEncodedStr = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";

            DiscoverSingleCharacterKey key = new DiscoverSingleCharacterKey(hexEncodedStr);
            
            
        }
    }
}
