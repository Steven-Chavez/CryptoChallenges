using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set1Challenge1_convertHexToBase64
{
    /// <summary>
    /// Author: Steven Chavez
    /// Date: 4/5/2017
    /// File: set1Challenge1_convertHexToBase64.cs
    /// 
    /// Set 1 challenge 1 of the crypto challenges. Convert Hex to Base64.
    /// Challenge located at http://cryptopals.com/sets/1/challenges/1
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string hexValue = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            string[] twoDigitHexValueSeperation = new string[(hexValue.Length/2)];
            byte[] hexToByteConversion = new byte[twoDigitHexValueSeperation.Length];
            int index = 0;

            // seperate hex values into pairs 
            for(int i = 0; i < hexValue.Length; i++)
            {
                if(0 == i % 2)
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

            // encode byte array into Base64
            string base64 = Convert.ToBase64String(hexToByteConversion);
            Console.WriteLine(base64);
        }
    }
}
