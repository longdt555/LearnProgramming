using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn10_9
{
    public static class Helper
    {
        public static string GetValue(string message)
        {
            Console.WriteLine($"{message}: ");
            return Console.ReadLine();
        }
        public static int ConvertToInt<T>(T value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
    }
}
