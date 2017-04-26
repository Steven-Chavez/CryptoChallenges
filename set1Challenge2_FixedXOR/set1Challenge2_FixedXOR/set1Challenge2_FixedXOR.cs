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
            // Declare variable for hexadecimal values.
            string hex1 = "1c0111001f010100061a024b53535009181c";
            string hex2 = "686974207468652062756c6c277320657965";
            string result = "";

            // Create an object of the HexConverter class.
            HexConverter hex = new HexConverter();

            // Pass hex values to be XOR encoded.
            result = hex.xOrEncoding(hex1, hex2);

            // Display results. Class method should produce:
            // 746865206b696420646f6e277420706c6179
            Console.WriteLine(result);
        }
    }
}
