using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set1Challenge1_convertHexToBase64
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexValue = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            string[] twoDigitHexValueSeperation = new string[(hexValue.Length)];
            
            for(int i = 0; i < hexValue.Length; i++)
            {
                twoDigitHexValueSeperation[i] = hexValue.ElementAt(i).ToString() + hexValue.ElementAt(i + 1).ToString();
                i++;
            }
        }
    }
}
