using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Lesson.Common.Helpers
{
    public static class DayOfWeek
    {
        public static string Monday = "MD";
        public static int Tuesday = 3;
    }


    // junior, senior
    public static class IdentityLesson
    {
        public static int Lesson1 = 1;
        public static int Lesson2 = 2;
        public static int Lesson3 = 3;
        public static int Lesson4 = 4;
        public static int Lesson5 = 5;
        public static int Lesson6 = 6;
        public static int Lesson7 = 7;
    }

    public static class Constants // copy / paste => coder => developer
    {
        public static string Rule = "[a-zA-Z]";
        public static string emailRule = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        public static string phoneNumberRule = $@"J\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})";
    }
}
