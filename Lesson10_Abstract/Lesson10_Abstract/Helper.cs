﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_Abstract
{
    public static class Helper
    {
        public static string GetValue(string message)
        {
            Console.Write($"{message}: ");
            return Console.ReadLine();
        }
    }
}
