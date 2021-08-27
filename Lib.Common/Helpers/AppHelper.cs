using System;
using static System.Console;
using static System.Int32;

namespace Lesson.Common.Helpers
{
    public static class AppHelper
    {
        public static int ConvertStringToInt(string value)
        {
            return TryParse(value, out int outValue) ? outValue : 0;
        }

        public static string RomanNumeralFrom(int number)
        {
            return
                new string('I', number)
                    .Replace(new string('I', 1000), "M")
                    .Replace(new string('I', 900), "CM")
                    .Replace(new string('I', 500), "D")
                    .Replace(new string('I', 400), "CD")
                    .Replace(new string('I', 100), "C")
                    .Replace(new string('I', 90), "XC")
                    .Replace(new string('I', 50), "L")
                    .Replace(new string('I', 40), "XL")
                    .Replace(new string('I', 10), "X")
                    .Replace(new string('I', 9), "IX")
                    .Replace(new string('I', 5), "V")
                    .Replace(new string('I', 4), "IV");
        }

        public static string GetValueFromKeyBoard(string msg)
        {
            Write($@"{msg}: ");
            return ReadLine();
        }
    }
}
