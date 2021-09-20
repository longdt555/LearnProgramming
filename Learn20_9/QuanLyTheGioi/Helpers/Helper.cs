using System;

namespace QuanLyTheGioi.Helpers
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
