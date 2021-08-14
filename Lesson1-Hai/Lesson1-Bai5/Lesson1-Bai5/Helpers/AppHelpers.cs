using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Lesson1_Bai5.Helpers
{
    public static class AppHelpers
    {
        public static string GetValueFromKeyBoard(string message)
        {
            WriteLine($"{message}");
            return ReadLine();
        }
    }
}
