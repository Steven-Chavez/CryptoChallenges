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
        private string base64;
        private string[] twoDigitHexValueSeperation;
        private byte[] byteConversion;
        private int index = 0;

        public HexConverter(string _hexdecimal)
        {
            hexdecimal = _hexdecimal;
        }

        public string getBase64()
        {
            separateHexValuesIntoPairs();
            hexToByteConversion();
            base64 = Convert.ToBase64String(byteConversion);
            return base64;
        }

        private void separateHexValuesIntoPairs()
        {
            twoDigitHexValueSeperation = new string[hexdecimal.Length / 2];
            int index = 0;

            // seperate hex values into pairs 
            for (int i = 0; i < hexdecimal.Length; i++)
            {
                if (0 == i % 2)
                {
                    twoDigitHexValueSeperation[index] = hexdecimal.ElementAt(i).ToString() 
                        + hexdecimal.ElementAt(i + 1).ToString();
                    index++;
                }
            }
        }

        private void hexToByteConversion()
        {
            byteConversion = new byte[twoDigitHexValueSeperation.Length];

            for (int i = 0; i < byteConversion.Length; i++)
            {
                byteConversion[i] = Convert.ToByte(Convert.ToInt32(twoDigitHexValueSeperation[i], 16));
            }
        }
    }
}
