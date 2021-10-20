using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.Helper
{
    public static class Helper
    {
        public static string GetValue(string msg)
        {
            Console.Write($"{msg}: ");
            return Console.ReadLine();
        }
        public static int ConvertToInt<T>(T msg)
        {
            try
            {
                return Convert.ToInt32(msg);
            }
            catch
            {
                return 0;
            }
        }

        public static string CombineQuery<T>(T value)
        {
            if (value.GetType() == typeof(string))
                return $@"'{value}'";
            return $"{value}";
        }
    }
}
