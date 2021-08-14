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


/*
 *
 *
using System;
using System.Text;
using static System.Console;

namespace Lesson1_Bai5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            var isValid = true;
            TinhLuong: do
            {
                if (!isValid)
                {
                    var option = GetValueFromKeyBoard("Bạn có muốn thử lại không (Y/N): ").ToUpper();
                    switch (option)
                    {
                        case "Y":
                            isValid = true;
                            break;
                        case "N":
                            isValid = false;
                            break;
                        default:
                            isValid = false;
                            break;
                    }
                }

                if (!isValid) break;
                try
                {
                    var bacLuong = Convert.ToInt64(GetValueFromKeyBoard("Nhập bậc lương hiện tại của bạn: "));

                    var ngayCong = Convert.ToInt64(GetValueFromKeyBoard("Nhập ngày công thực tế của bạn: "));

                    var phuCap = Convert.ToInt64(GetValueFromKeyBoard("Nhập phụ cấp của bạn: "));

                    var tienLanh = bacLuong * Constants.Rate;

                    const string commonStr = "Lương của bạn là: ";
                    WriteLine(ngayCong <= 2 ? $@"{commonStr}{tienLanh * (ngayCong * 2) + phuCap}" : $@"{commonStr}{tienLanh * ngayCong + phuCap}");
                }
                catch (Exception)
                {
                    WriteLine("Có lỗi xảy ra vùi lòng thử lại sau.");
                    isValid = false;
                }

            } while (!isValid);

            var optionExit = GetValueFromKeyBoard("Bạn có muốn thoát chương trình không (Y/N): ").ToUpper();
            switch (optionExit)
            {
                case "Y":
                    Beep();
                    WriteLine("Tạm biệt ");
                    break;

                case "N":
                    isValid = true;
                    goto TinhLuong;

                default:
                    Beep();
                    WriteLine("Tạm biệt ");
                    break;
            }
        }

        #region [Private functions helper]

        private static string GetValueFromKeyBoard(string message)
        {
            Write($@"{message}");
            return ReadLine();
        }


        #endregion [Private functions helper]

        #region [Common Data]

        public static class Constants
        {
            public const double Rate = 650000;
        }

        #endregion [Common Data]

    }
}
 */