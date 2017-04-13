using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set1Challenge2_FixedXOR
{
    /// <summary>
    /// Author: Steven Chavez
    /// Date: 4/6/2017
    /// File: set1Challenge2_FixedXOR.cs
    /// 
    /// Set 1 challenge 2 of the crypto challenges. Write a function
    /// that takes two equal-length buffers and produces their XOR 
    /// combination. Exclusive OR is only true if one or the other 
    /// is true but not both. http://cryptopals.com/sets/1/challenges/2
    /// </summary>
    class set1Challenge2_FixedXOR
    {
        static void Main(string[] args)
        {
            HexConverter hex = new HexConverter("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d");
            Console.WriteLine(hex.getBase64());

        }
    }
}
