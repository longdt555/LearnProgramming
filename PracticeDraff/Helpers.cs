using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeDraff
{
    public static class Helpers
    {
        // convert value to int => Value: int, string, float, double, etc
        public static int ConvertStringToInt(string value)
        {
            return Convert.ToInt32(value);
        }

        public static int ConvertFloatToInt(float value)
        {
            return Convert.ToInt32(value);
        }

        public static int ConvertDoubleToInt(double value)
        {
            return Convert.ToInt32(value);
        }

        // generic 
        public static int ConvertValueToInt<T>(T model)
        {
            return Convert.ToInt32(model);
        }
    }
}
