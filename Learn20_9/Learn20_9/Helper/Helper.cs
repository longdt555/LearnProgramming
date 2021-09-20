using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn20_9.Helper
{
    public static class Helper
    {
        public static string GetValue(string value)
        {
            Console.Write($"{value}: ");
            return Console.ReadLine();
        }
        public static int ConvertToInt<T>(T value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
    }
}
