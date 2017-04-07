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

        }

        /// <summary>
        /// Decodes hexadecimal strings into a byte array
        /// </summary>
        /// <param name="hexValue"></param>
        /// <returns>byte array</returns>
        public byte[] hexDecoder(string hexValue)
        {
            string[] twoDigitHexValueSeperation = new string[(hexValue.Length / 2)];
            byte[] hexToByteConversion = new byte[twoDigitHexValueSeperation.Length];
            int index = 0;

            // seperate hex values into pairs 
            for (int i = 0; i < hexValue.Length; i++)
            {
                if (0 == i % 2)
                {
                    twoDigitHexValueSeperation[index] = hexValue.ElementAt(i).ToString() + hexValue.ElementAt(i + 1).ToString();
                    index++;
                }
            }

            // convert hex pairs into bytes
            for (int i = 0; i < hexToByteConversion.Length; i++)
            {
                hexToByteConversion[i] = Convert.ToByte(Convert.ToInt32(twoDigitHexValueSeperation[i], 16));
            }

            return hexToByteConversion;
        }
    }
}
