using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lesson.Common.Enums;
using Lesson.Common.Helpers;
using static System.Console;
using static Lesson.Common.Helpers.AppHelper;
using static Practice.Lesson2;
using static Practice.Lesson3;
using static Practice.Lesson4;
using static Practice.ListInCSharp;
using IdentityLesson = Lesson.Common.Enums.IdentityLesson;

namespace Practice
{
    public class Program
    {
        // Biến toàn cục - Global variable
        public const string Actor = "YONG";

        public const int Lesson = 5;

        public static void Main(string[] args)
        {
            ////Vietnamese character in .NET Console Application (UTF-8)
            //OutputEncoding = Encoding.UTF8;
            //ForegroundColor = ConsoleColor.DarkGreen;

            //PrintLesson();

            //EnterLesson: var value = GetOptionFromKeyBoard("Enter the lesson you wanna see: ");
            //while (value > 0)
            //{
            //    Clear();
            //    switch (value)
            //    {
            //        case (int)IdentityLesson.Lesson1: // Lesson 1
            //            WriteLine("Hello, this is lesson 1");

            //            DoEndLesson(value);
            //            goto EnterLesson;

            //        case 2:
            //            PrintSubLesson(value);
            //            EnterSubLesson: var subOption = GetOptionFromKeyBoard("Enter the sub-lesson you wanna see: ");
            //            while (subOption > 0)
            //            {
            //                Clear();
            //                switch (subOption)
            //                {
            //                    case 1:
            //                        Parameter();

            //                        DoEndSubLesson(value, subOption);
            //                        goto EnterSubLesson;

            //                    case 2:
            //                        ReferenceType();

            //                        DoEndSubLesson(value, subOption);
            //                        goto EnterSubLesson;

            //                    case 3:
            //                        ValueType();

            //                        DoEndSubLesson(value, subOption);
            //                        goto EnterSubLesson;
            //                    case 4:
            //                        ConditionStatement();

            //                        DoEndSubLesson(value, subOption);
            //                        goto EnterSubLesson;
            //                    default:
            //                        DoEndSubLesson(value, subOption, false);
            //                        goto EnterSubLesson;
            //                }
            //            }

            //            DoEndLesson(value);
            //            goto EnterLesson;

            //        case 3:
            //            Array();
            //            DoEndLesson(value);
            //            goto EnterLesson;

            //        case 4:

            //            List<Student1> students = new List<Student1>();

            //            var student = new Student1()
            //            {
            //                Name = "Long"
            //            };

            //            students.Add(student);

            //            foreach (var student1 in students)
            //            {
            //                WriteLine(student1.Name);
            //            }

            //            //ShowEnum();
            //            //WriteLine((int)Color1.RED);
            //            //var student = AddStudentIntoClass();
            //            //WriteLine(student);
            //            DoEndLesson(value);
            //            goto EnterLesson;

            //        default:
            //            DoEndLesson(value, false);
            //            goto EnterLesson;

            //    }
            //}

            //Beep();
            //WriteLine("-------------------------------------------------------END-------------------------------------------------------");
            //ReadKey();


            List<Student1> students = new List<Student1>(); // class

            //// _ nhập liệu
            /// 
            var maxStudent = students.Any() ? students.Max(x => x.Id) + 1 : 1;


            var student = new Student1()
            {
                Id = students.Any() ? students.Max(x => x.Id) + 1 : 1, // 1 -> 1
                Name = "Long"
            };
            students.Add(student); // add 1 phần tử vào cuối mảng

            var student2 = new Student1()
            {
                Id = students.Any() ? students.Max(x => x.Id) + 1 : 1, // 1 -> 2
                Name = "Long"
            };
            students.Add(student2); // add 1 phần tử vào cuối mảng
            students.Remove(students.FirstOrDefault(x => x.Id == 1));
            foreach (var student1 in students)
            {
                WriteLine($"{student1.Id} - {student1.Name}");
            }

            /// Thêm -> tạo đối tượng -> add
            /// Sửa -> tìm ra thằng muốn sửa -> sửa
            /// Xóa -> Tìm thằng muốn xóa -> Xóa

        }

        #region [Private functions helper]


        /// <summary>
        /// Show message and display the lesson list again
        /// </summary>
        /// <param name="lesson"></param>
        /// <param name="isValidLesson"></param>
        private static void DoEndLesson(int lesson, bool isValidLesson = true)
        {
            if (isValidLesson)
            {
                WriteLine(Environment.NewLine);
                WriteLine($"-------------------------------------------------------END of Lesson {RomanNumeralFrom(lesson)}-------------------------------------------------------");
                WriteLine(Environment.NewLine);

                PrintLesson();
            }
            else
            {
                WriteLine(Environment.NewLine);
                WriteLine("-------------------------------------------------------You chose the wrong option-------------------------------------------------------");
                WriteLine(Environment.NewLine);

                PrintLesson();
            }

        }

        /// <summary>
        /// Show message and display the sub-lesson list again
        /// </summary>
        /// <param name="lesson"></param>
        /// <param name="subLesson"></param>
        /// <param name="isValidSubLesson"></param>
        private static void DoEndSubLesson(int lesson, int subLesson, bool isValidSubLesson = true)
        {
            if (isValidSubLesson)
            {
                WriteLine(Environment.NewLine);
                WriteLine($"-------------------------------------------------------END of Lesson {RomanNumeralFrom(subLesson)}-------------------------------------------------------");
                WriteLine(Environment.NewLine);

                PrintSubLesson(lesson);
            }
            else
            {
                WriteLine(Environment.NewLine);
                WriteLine("-------------------------------------------------------You chose the wrong sub-option-------------------------------------------------------");
                WriteLine(Environment.NewLine);

                PrintSubLesson(lesson);
            }

        }

        public static int GetOptionFromKeyBoard(string msg)
        {
            Write($@"{msg}");
            var value = ReadLine();
            if (RuleChecking(value, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
                return 1;
            return -1;
        }

        private static bool RuleChecking(string message, string rule)
        {
            var re = new Regex(rule);
            return re.IsMatch(message);
        }

        private static void PrintLesson()
        {
            WriteLine(@"------LIST OF LESSONS IN THE COURSE------");

            WriteLine(@"0: EXIT!!!");
            for (var i = 1; i < Lesson; i++)
            {
                var nameOfLesson = i switch
                {
                    1 => "Git - Variable, Constant, Operation - Console Application",
                    2 => "DATA TYPE – Reference Type - Value Type – Condition Statement – Loop",
                    3 => "Array – Handle STRING - Handle Exception",
                    4 => "Struct - Enum - Regular Expression",
                    _ => string.Empty
                };
                WriteLine($@"{i}: Lesson {RomanNumeralFrom(i)} - {nameOfLesson}");
            }
        }

        private static void PrintSubLesson(int lesson)
        {
            WriteLine($@"------LIST OF SUB-LESSONS IN THE LESSON {RomanNumeralFrom(lesson)}------");

            WriteLine(@"0: EXIT!!!");
            switch (lesson)
            {
                case 1:
                    WriteLine("Hello");
                    break;
                case 2:
                    WriteLine("1: Parameter");
                    WriteLine("2: Reference type");
                    WriteLine("3: Value type");
                    WriteLine("4: Condition statement");
                    WriteLine("5: Loop");
                    break;
            }
        }

        #endregion  [Private functions helper]
    }
}
