using System;

namespace ColorConverter;

class Colors
{
    public static class Arrays
    {
        private static string[] _hexArray = new string[3];
        public static string[] HexArray
        {
            get { return _hexArray; }
            set { _hexArray = value; }
        }

        private static string[] _rgbArray = new string[3];
        public static string[] RgbArray
        {
            get { return _rgbArray; }
            set { _rgbArray = value; }
        }
    }

    public static class Codes
    {
        public static string HexCode
        {
            get => BuildColorResult(Arrays.HexArray, "#");
        }

        public static string RgbCode
        {
            get => BuildColorResult(Arrays.RgbArray);
        }

        private static string BuildColorResult(string[] colors, string initialValue = "")
        {
            string result = initialValue;

            foreach (string color in colors)
            {
                result += color;
            }

            return result;
        }
    }

    public static class ConvertFrom
    {
        public static void RgbToHex(string[] rgb)
        {
            string[] hexList = Arrays.HexArray;

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
            string[] rgbList = Arrays.RgbArray;

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
