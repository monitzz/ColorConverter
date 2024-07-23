using System;

namespace ColorConverter;

class Colors
{
    public static class Codes
    {
        private static string[] _hexCode = new string[3];
        public static string[] HexCode
        {
            get { return _hexCode; }
            set { _hexCode = value; }
        }

        private static string[] _rgbCode = new string[3];
        public static string[] RgbCode
        {
            get { return _rgbCode; }
            set { _rgbCode = value; }
        }
    }

    public static class ConvertFrom
    {
        public static void RgbToHex(string[] rgb)
        {
            string[] hexList = Codes.HexCode;

            for (int i = 0; i < rgb.Length; i++)
            {
                byte color = Convert.ToByte(rgb[i]);

                if (color > 255)
                {
                    color = 255;
                }
                else if (!byte.TryParse(rgb[i], out _))
                {
                    color = 0;
                }

                string hexNum = Convert.ToString(color, 16);

                if (hexNum.Length == 1)
                {
                    hexNum = "0" + hexNum;
                }

                hexList[i] = hexNum;
            }
        }
        
        public static void HexToRgb(string[] hex)
        {
            string[] rgbList = Codes.RgbCode;

            for (sbyte i = 0; i < hex.Length; i++)
            {
                if (hex[i].Length == 1)
                {
                    hex[i] = "0" + hex[i];
                }

                string rgbString = hex[i];

                if (rgbString.Length == 1)
                {
                    rgbString = "0" + rgbString;
                }

                byte rgbValue = Convert.ToByte(rgbString, 16);
                rgbList[i] = Convert.ToString(rgbValue);
            }
        }
    }
}
