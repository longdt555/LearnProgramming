using System;
using System.Net;
using System.Text;
using Lesson1_Bai5.Common;
using static System.Console;

namespace Lesson1_Bai5
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Yellow;

            EnterOption: int optionSelected = ConvertStringToInt(GetValueFromKeyBoard("tính năng mày muốn dùng")); // 1
            
            // Số lần nhập sai và thời gian nhập sai, nếu nhập sai quá 2 lần thi thoát và in ra số lần nhập sai kèm thời gian nhập sai: Datetime.Now
            switch (optionSelected)
            {
                case 0:
                    break;

                case 1:
                    int bacLuong = ConvertStringToInt(GetValueFromKeyBoard("bậc lương hiện tại của bạn"));
                    int ngayCong = ConvertStringToInt(GetValueFromKeyBoard("ngày công thực tế của bạn"));
                    int phuCap = ConvertStringToInt(GetValueFromKeyBoard("phụ cấp hiện tại của bạn"));

                    WriteLine($"Lương của bạn là: {CalculateSalary(phuCap: phuCap, bacLuong: bacLuong, ngayCong: ngayCong)}");
                    goto EnterOption;

                case 2:
                    int number1 = ConvertStringToInt(GetValueFromKeyBoard("thứ nhất"));
                    int number2 = ConvertStringToInt(GetValueFromKeyBoard("thứ 2"));

                    WriteLine($@"Tổng của 2 số {number1} và {number2} là: {Sum(number1, number2)}");// escape special character
                    goto EnterOption;

                default:
                    goto EnterOption;
            }

            // Do not care about that, lol.
            WriteLine($"Mời bạn cút!!!");
        }


        public static string GetValueFromKeyBoard(string message)
        {
            Write($"Nhập vào {message}: ");
            return ReadLine();
        }


        private static int CalculateSalary(int bacLuong, int ngayCong, int phuCap)
        {
            return ngayCong <= 15 ? bacLuong * Constants.salaryRate + ngayCong + phuCap : (ngayCong - 25) * 2 + 25;
        }

        private static int ConvertStringToInt(string value)
        {
            return Int32.TryParse(value, out int ouputValue) ? ouputValue : 10;
        }

        private static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        private static int Sum(int num1, int num2, int num3)
        {
            return num1 + num2 + num3;
        }
    }
}