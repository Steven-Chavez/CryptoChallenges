using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set1Challenge2_FixedXOR
{
    /// <summary>
    /// Author: Steven Chavez
    /// Date: 4/25/2017
    /// File: HexConverter.cs
    /// Version: 1.0
    /// 
    /// Handles convertions of hexadecimal values. Plus some
    /// encoding of hexadecimal values.
    /// </summary>
    class HexConverter
    {
        private string hexadecimal;
        private string xOrHex1;
        private string xOrHex2;
        private string base64;
        private string[] twoDigitHexValueSeperation;
        private byte[] byteConversion;

        /// <summary>
        /// Defualt constructor. 
        /// </summary>
        public HexConverter()
        {
            hexadecimal = "";
        }

        /// <summary>
        /// Overloaded Constructor.
        /// </summary>
        /// <param name="_hexdecimal">Assigns hexadecimal value</param>
        public HexConverter(string _hexadecimal)
        {
            hexadecimal = _hexadecimal;
            twoDigitHexValueSeperation = separateHexValueIntoPairs(hexadecimal);
            byteConversion = hexToByteConversion(twoDigitHexValueSeperation);
        }

        /// <summary>
        /// Get Base64 value of a hexadecimal value
        /// </summary>
        /// <returns>base64</returns>
        public string getBase64()
        {
            base64 = Convert.ToBase64String(byteConversion);
            return base64;
        }

        /// <summary>
        /// Seperate hexadecimal string into an array by pairs.
        /// Making the hexadecimal value easy to do work on.
        /// </summary>
        /// <param name="hex">Hexadecimal string to be seperated</param>
        /// <returns>Paired hexadecimal array</returns>
        private string[] separateHexValueIntoPairs(string hex)
        {
            string[] hexValueSeperation = new string[hex.Length / 2];
            int index = 0;

            // Seperate hex values into pairs.
            for (int i = 0; i < hex.Length; i++)
            {
                // Allows for pulling of pairs from even indices
                if (0 == i % 2)
                {
                    hexValueSeperation[index] = hex.ElementAt(i).ToString() 
                        + hex.ElementAt(i + 1).ToString();
                    index++;
                }
            }
            return hexValueSeperation;
        }

        /// <summary>
        /// Converts paired hex array values into a byte array. Working
        /// with the raw bytes makes converting and encoding easier.
        /// </summary>
        /// <param name="seperatedHex">Seperated hexadecimal string array</param>
        /// <returns>Converted byte array</returns>
        private byte[] hexToByteConversion(string[] seperatedHex)
        {
            byte[] conversion = new byte[twoDigitHexValueSeperation.Length];

            for (int i = 0; i < conversion.Length; i++)
            {
                conversion[i] = Convert.ToByte(Convert.ToInt32(twoDigitHexValueSeperation[i], 16));
            }

            return conversion;
        }

        /// <summary>
        /// Takes equal length hex strings and encodes using XOR
        /// </summary>
        /// <param name="_xOrHex1">hexadecimal string</param>
        /// <param name="_xOrHex2">hexadecimal string</param>
        /// <returns>XOR hexadecimal encoded value</returns>
        public string xOrEncoding(string _xOrHex1, string _xOrHex2)
        {
            // Ensure that both hex string are equal in length
            if(_xOrHex1.Length != _xOrHex2.Length)
            {
                return "Both hex strings need to be equal-length";
            }
            else
            {
                // Declare variable.
                xOrHex1 = _xOrHex1;
                xOrHex2 = _xOrHex2;

                // Function value holding varibles.
                byte[] hex1 = new byte[hexadecimal.Length];
                byte[] hex2 = new byte[hexadecimal.Length];
                string results;

                // Seperate hex values into pairs and then convert to byte array.
                twoDigitHexValueSeperation = separateHexValueIntoPairs(xOrHex1);
                hex1 = hexToByteConversion(twoDigitHexValueSeperation);
                twoDigitHexValueSeperation = separateHexValueIntoPairs(xOrHex2);
                hex2 = hexToByteConversion(twoDigitHexValueSeperation);

                // Get encoded XOR string
                results = xOrEncodeCalc(hex1, hex2);

                return results;
            }
        }

        /// <summary>
        /// Performs all the XOR encoding on the byte array hex pair
        /// values. 
        /// </summary>
        /// <param name="hex1">byte array of hex value pairs</param>
        /// <param name="hex2">byte array of hex value pairs</param>
        /// <returns>XOR encoded string</returns>
        private string xOrEncodeCalc(byte[] hex1, byte[] hex2)
        {
            string[] byte1 = new string[hex1.Length];
            string[] byte2 = new string[hex2.Length];
            string[] encodedByte = new string[hex1.Length];
            string encodedHex = "";

            // get raw byte value for encoding
            for (int i = 0; i < byte1.Length; i++)
            {
                byte1[i] = (Convert.ToString(hex1[i], 2));
                byte2[i] = (Convert.ToString(hex2[i], 2));

                if (byte1[i].Length < 8)
                {
                    byte1[i] = byte1[i].PadLeft(8, '0');
                }

                if (byte2[i].Length < 8)
                {
                    byte2[i] = byte2[i].PadLeft(8, '0');
                }
            }

            // get XOR encoded byte string
            for(int i = 0; i < byte1.Length; i++)
            {
                int encodedDecimal = 0;
                encodedByte[i] = "";
                for (int j = 0; j < 8; j++)
                {
                    if(byte1[i].ElementAt(j) == byte2[i].ElementAt(j))
                    {
                        encodedByte[i] += "0";
                    }
                    else
                    {
                        encodedByte[i] += "1";
                    }
                }
                encodedDecimal = Convert.ToInt32((encodedByte[i]), 2);
                encodedHex += encodedDecimal.ToString("X");
            }

            return encodedHex;
        }
    }
}
