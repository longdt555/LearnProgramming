using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    public static class HelpersFunc
    {

        // Tái sử dụng
        // Tối ưu mã nguồn
        public static int ConvertValueToInt<T>(T value)
        {
            return Convert.ToInt32(value);
        }

        // normal way 
        public static int ConvertStringToInt(string value)
        {
            return Convert.ToInt32(value);
        }
        public static int ConvertFloatToInt(float value)
        {
            return Convert.ToInt32(value);
        }
    }

}
    