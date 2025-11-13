using System;
using GloryDay.Debug.Log;

namespace Library.UI.CommandConsole.Utils
{
    public static class TypeConverter
    {
        public static bool ToBoolean(string value)
        {
            bool data;
            
            try
            {
                data = bool.Parse(value);
            }
            catch (FormatException exception)
            {
                LogManager.LogError(exception.Message);

                data = default;
            }

            return data;
        }
        
        public static char ToChar(string value)
        {
            char data;

            try
            {
                var length = value.Length;
                if (value[0] != '\'' || value[length - 1] != '\'' || length != 3)
                {
                    throw new FormatException("String was not recognized as a valid Char");
                }

                data = char.Parse(value.Trim('\''));
            }
            catch (FormatException exception)
            {
                LogManager.LogError(exception.Message);

                data = default;
            }

            return data;
        }

        public static string ToString(string value)
        {
            return value;
        }

        public static byte ToByte(string value)
        {
            byte data;
            
            try
            {
                data = byte.Parse(value);
            }
            catch (FormatException exception)
            {
                LogManager.LogError(exception.Message);

                data = default;
            }

            return data;
        }

        public static short ToShort(string value)
        {
            short data;
            
            try
            {
                data = short.Parse(value);
            }
            catch (FormatException exception)
            {
                LogManager.LogError(exception.Message);

                data = default;
            }

            return data;
        }
        
        public static int ToInt(string value)
        {
            int data;
            
            try
            {
                data = int.Parse(value);
            }
            catch (FormatException exception)
            {
                LogManager.LogError(exception.Message);

                data = default;
            }

            return data;
        }

        public static long ToLong(string value)
        {
            long data;
            
            try
            {
                data = long.Parse(value);
            }
            catch (FormatException exception)
            {
                LogManager.LogError(exception.Message);

                data = default;
            }

            return data;
        }

        public static float ToFloat(string value)
        {
            float data;
            
            try
            {
                data = float.Parse(value);
            }
            catch (FormatException exception)
            {
                LogManager.LogError(exception.Message);

                data = default;
            }

            return data;
        }

        public static double ToDouble(string value)
        {
            double data;
            
            try
            {
                data = double.Parse(value);
            }
            catch (FormatException exception)
            {
                LogManager.LogError(exception.Message);

                data = default;
            }

            return data;
        }

        public static decimal ToDecimal(string value)
        {
            decimal data;
            
            try
            {
                data = decimal.Parse(value);
            }
            catch (FormatException exception)
            {
                LogManager.LogError(exception.Message);

                data = default;
            }

            return data;
        }
    }
}