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
            HexConverter hex = new HexConverter("1c0111001f010100061a024b53535009181c");
            byte[] byteHex = hex.getByteArray();

            string test = hex.xOrEncoding("686974207468652062756c6c277320657965");
            Console.WriteLine(test);
        }
    }
}
