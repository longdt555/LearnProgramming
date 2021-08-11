using System;
using static System.Console;
using static Lesson.Common.Helpers.AppHelper;

namespace Practice
{
    public static class Lesson2
    {

        #region [Parameter]

        public static void Parameter()
        {
            WriteLine("-------------------------------------------------------(Tham số)-------------------------------------------------------");
            // Biến cục bộ - Local variable
            var actorName = "YONG";

            // Gọi thông thường
            PrintMyFullName("ĐINH", $@"{actorName}G");

            // Gọi theo tên của tham số
            PrintMyFullName(lastName: actorName, sureName: "DINH");

            // Gọi theo tên của tham số
            PrintMyFullName("DINH");
        }

        #endregion  [Parameter]

        #region [Reference Type - Tham chiếu]

        public static void ReferenceType()
        {
            var number = 5;
            WriteLine("-------------------------------------------------------(Tham chiếu (Reference Type))-------------------------------------------------------");
            // Tham số kiểu kham chiếu  - Làm thay đổi giá trị 
            WriteLine("-------------------------------------------------------(1st way: REF)-------------------------------------------------------");
            // 1st way: REF
            Square(ref number);
            WriteLine($@"Number in Main: {number}");

            Square(ref number);
            WriteLine($@"Number in Main: {number}");

            Square(ref number);
            WriteLine($@"Number in Main: {number}");
            WriteLine("-------------------------------------------------------(2st way: OUT)-------------------------------------------------------");
            // 2st way: OUT
            Square(5, out var outNumber);
            WriteLine($@"Out number: {outNumber}");
            Square(outNumber);

            WriteLine("-------------------------------------------------------(Tham số là object -> Tham chiếu)-------------------------------------------------------");
            // Tham số là một đối tượng sẽ được gọi là tham chiếu
            var person = new Person();
            WriteLine($@"Before, Person's age: {person.Age}");

            SquareAge(person);

            WriteLine($@"After, Person's age: {person.Age}");
        }

        #endregion [Reference Type - Tham chiếu]



        #region [Reference Type - Tham chiếu]

        public static void ValueType()
        {
            WriteLine("-------------------------------------------------------(Tham trị (Value Type))-------------------------------------------------------");
            // Tham số kiểu tham trị - Không làm thay đổi giá trị 
            var number2 = 5;
            Square(number2);

            WriteLine($@"Number in Main: {number2}");
        }

        #endregion [Reference Type - Tham chiếu]


        #region [Lệnh, cấu trúc rẽ nhánh với if else]

        public static void ConditionStatement()
        {
            #region [IF ELSE]

            /*
             if (condition)
                 // do something if condition is true
            
             if (condition){
                 if (condition){
                     // do something if condition is true
                 }else{
                 // do something if condition is false
                 }
             }

             if (condition){
                 // do something if condition is true
             }else{
                 // do something if condition is false
             }

            if (condition){
                 // do something if condition is true
             }else if (condition){
                 // do something if condition is false
             }else{
                 // do something if condition is false
            }
            */
            var number = GetOptionFromKeyBoard("Enter your number:");

            //if (number % 2 == 0)
            //    WriteLine($"{number} is even number.");
            //else
            //    WriteLine($"{number} is odd number.");

            //if (number == 1)
            //    WriteLine($"1");
            //else if (number < 5)
            //    WriteLine($"<5");
            //else if (number < 10)
            //    WriteLine($"<10");

            // (condition) ? expression : expression;
            WriteLine(number % 2 == 0 ? $"{number} is even number." : $"{number} is odd number.");

            #endregion [IF ELSE]

            #region [Switch Case]

            //switch (expr)
            //{
            //    case expr1:
            //        expression
            //        break;
            //    case expr2:
            //        expression
            //        break;

            //    // ...

            //    default:
            //        //..
            //        break;
            //}

            #endregion [Switch Case]


            #region [For]

            //for (initial; condition; update)
            //{
            //    expression
            //}

            #endregion [For]

            #region [While]

            //while (condition)
            //{
            //    //if condition is true, do something
            //}

            #endregion [While]

            #region [Do...While]
            // always do one time
            //do
            //{
            //    //Khối lệnh
            //}
            //while (điều_kiện);

            #endregion [Do...While] 

            //

            #region [Goto - Continue - Break]

            var eventNumber = string.Empty;
            for (var i = 1; i <= 20; i++)
            {
                if (i % 2 != 0)
                    continue;  // Chạy ngay vòng lặp tiếp

                eventNumber += string.IsNullOrEmpty(eventNumber) ? $@"{i}" : $@" {i}";
            }
            WriteLine("Even number from 1-20 " + eventNumber);

            for (var i = 1; i <= 20; i++)
            {
                if (i % 2 != 0)
                    continue;  // Chạy ngay vòng lặp tiếp

                eventNumber += string.IsNullOrEmpty(eventNumber) ? $@"{i}" : $@" {i}";
            }
            WriteLine("Even number from 1-20 " + eventNumber);
            
            while (true)
            {
                Write(" " + ++number);
                if (number == 20)
                    break;  // exit
            }
            #endregion [Continue - Break]
        }

        #endregion [Lệnh, cấu trúc rẽ nhánh với if else]

        #region [Private functions helper]

        private static void PrintMyFullName(string sureName, string lastName = "LONG")
        {
            WriteLine($@"My fullname is {sureName} {lastName}");
        }
        private static int GetOptionFromKeyBoard(string msg)
        {
            Write($@"{msg} ");
            return ConvertStringToInt(ReadLine());
        }

        #region [Tính bình phương của một số]

        private static void SquareAge(Person person)
        {
            person.Age *= person.Age;
        }

        private static void Square(int number)
        {
            var numberSquare = number * number;
            Write($@"Square of {number} is {numberSquare}");

            number = numberSquare;
            WriteLine($@" and Number in Square: {number}");
        }

        private static void Square(ref int number)
        {
            var numberSquare = number * number;
            Write($@"Square of {number} is {numberSquare}");

            number = numberSquare;
            WriteLine($@" and Number in Square: {number}");
        }

        private static void Square(int number, out int outNumber)
        {
            outNumber = number * number;
            Write($@"Square of {number} is {outNumber}");
            WriteLine($@" and Number in Square: {number}");
        }

        #endregion [Tính bình phương của một số]

        #endregion [Private functions helper]

    }
}
