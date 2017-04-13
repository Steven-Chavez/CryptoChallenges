using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set1Challenge2_FixedXOR
{
    class HexConverter
    {
        private string hexdecimal;
        private string xOrEncodingHex;
        private string base64;
        private string[] twoDigitHexValueSeperation;
        private byte[] byteConversion;

        public HexConverter(string _hexdecimal)
        {
            hexdecimal = _hexdecimal;
            twoDigitHexValueSeperation = separateHexValueIntoPairs(hexdecimal);
            byteConversion = hexToByteConversion(twoDigitHexValueSeperation);
        }

        public string getBase64()
        {
            base64 = Convert.ToBase64String(byteConversion);
            return base64;
        }

        public byte[] getByteArray()
        {
            return byteConversion;
        }

        private string[] separateHexValueIntoPairs(string hex)
        {
            string[] hexValueSeperation = new string[hex.Length / 2];
            int index = 0;

            // seperate hex values into pairs 
            for (int i = 0; i < hex.Length; i++)
            {
                if (0 == i % 2)
                {
                    hexValueSeperation[index] = hex.ElementAt(i).ToString() 
                        + hex.ElementAt(i + 1).ToString();
                    index++;
                }
            }
            return hexValueSeperation;
        }

        private byte[] hexToByteConversion(string[] seperatedHex)
        {
            byte[] conversion = new byte[twoDigitHexValueSeperation.Length];

            for (int i = 0; i < conversion.Length; i++)
            {
                conversion[i] = Convert.ToByte(Convert.ToInt32(twoDigitHexValueSeperation[i], 16));
            }

            return conversion;
        }

        
        public string xOrEncoding(string _xOrEncodingHex)
        {
            if(_xOrEncodingHex.Length != hexdecimal.Length)
            {
                return "Both hex strings need to be equal-length";
            }
            else
            {
                // declare variable
                xOrEncodingHex = _xOrEncodingHex;

                // function value holding varibles 
                byte[] hex1 = new byte[hexdecimal.Length];
                byte[] hex2 = new byte[hexdecimal.Length];
                string results;

                hex1 = byteConversion;
                twoDigitHexValueSeperation = separateHexValueIntoPairs(xOrEncodingHex);
                hex2 = hexToByteConversion(twoDigitHexValueSeperation);

                results = produceXOrCombination(hex1, hex2);
                return results;
            }
        }

        private string produceXOrCombination(byte[] hex1, byte[] hex2)
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
