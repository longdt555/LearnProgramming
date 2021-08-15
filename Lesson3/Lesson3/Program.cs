using System;
using System.Text;
using static System.Console;
using System.Linq;
namespace Lesson3
{
    class Program
    {

        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Yellow;

            bool endProgram = false;

            while (!endProgram)
            {
                int option = getOption();



                switch (option)
                {
                    case 1:
                        bai1();
                        break;
                    case 2:
                        bai2();
                        break;
                    case 3:
                        bai3();
                        break;
                    case 4:
                        bai4();
                        break;
                    case 0:
                        Console.WriteLine("End program");
                        endProgram = true;
                        break;
                }

            }
        }
        private static void bai1()
        {
            // BÀI 1
            int Row, Col;
            Option1:  try {
                Console.Write("Mời nhập số hàng: ");
                Row = int.Parse(Console.ReadLine());
                Console.Write("Mời nhập số cột: ");
                Col = int.Parse(Console.ReadLine());

                int[,] IntArray = new int[Row, Col];

                for (int i = 0; i < IntArray.GetLength(0); i++)
                {
                    for (int j = 0; j < IntArray.GetLength(1); j++)
                    {
                        Console.Write("Nhập giá trị phần tử [{0},{1}]: ", i, j);
                        IntArray[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                int Sum = 0;
                Console.WriteLine("Mảng vừa nhập");

                for (int i = 0; i < IntArray.GetLength(0); i++)
                {
                    for (int j = 0; j < IntArray.GetLength(1); j++)
                    {
                        Console.Write("{0,3}", IntArray[i, j]);
                        Sum += IntArray[i, j];
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Tổng giá trị các phần tử trong mảng là: {0}", Sum);
            }
            catch(Exception a)
            {
                WriteLine("Hãy nhập số !!!");
                goto Option1;
            }
        }
    
        private static void bai2()
        {
        // BÀI 2
        EnterOption: try
            {
                int[] array = new int[10];

                for (int i = 0; i < array.Length; i++)
                {
                    Write($"Giá trị phần tử {i} là: ");
                    for (int j = 0; j < 1; j++)
                    {
                        array[j] = Convert.ToInt32(ReadLine());
                    }
                }

                Console.WriteLine($"Min: {array.Min()}");
                Console.WriteLine($"Max: {array.Max()}");

                int sum = array.Sum();

                Console.WriteLine($"Tổng giá trị mảng: {sum}");
                Console.WriteLine($"Trung bình cộng giá trị mảng: {sum / (array.Length)}");
            }
            catch (Exception a)
            {
                WriteLine("Vui lòng nhập số !!!");
                goto EnterOption;

            }
        }


        private static void bai3()
        {
            // BÀI 3
            string name = (GetName("Hãy nhập vào tên của bạn: "));

            WriteLine("Độ dài họ tên của bạn là: " + CaculateName(name)); // Độ dài chuỗi
            WriteLine(Tool.yourNameIs + ToLower(name));                   // In thường
            WriteLine(Tool.yourNameIs + ToUpper(name));                   // In hoa
            WriteLine(Tool.yourNameIs + ConvertToTitleCase(name));        // Viết hoa đầu từ 
            WriteLine(Tool.yourNameIs + RemoveWhitespace(name));          // Loại bỏ khoảng trắng

        }

        private static void bai4()
        {
        // BÀI 4
        Enter: try
            {
                while (true)
                {
                Option: WriteLine("Hãy nhập vào a: ");
                    float a = Convert.ToSingle(ReadLine());

                    if (a == 0)
                    {
                        WriteLine("a phải khác 0");
                        goto Option;
                    }
                    else
                    {
                        WriteLine("Nhập vào b: ");
                        float b = Convert.ToSingle(ReadLine());

                        float x = -b / a;
                        WriteLine("{0}x + {1} = 0 \n=> x = {2}", a, b, x);
                        break;
                    }

                }
            }
            catch (Exception a)
            {
                WriteLine("Vui lòng nhập số !!!");
                goto Enter;
            }

        }
        // BÀI 1.2
        public static string GetName(string name)
        {
            Write($"{name}: "); // Nhập 
            return ReadLine();
        }
        private static int CaculateName(string name)
        {
            return name.Length; // Độ dài chuỗi

        }
        private static string ToUpper(string name)
        {
            return name.ToUpper(); // In hoa
        }
        private static string ToLower(string name)
        {
            return name.ToLower(); // In thường
        }
        private static string ConvertToTitleCase(string name)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
        } // Viết hoa đầu từ 
        private static string RemoveWhitespace(string name)
        {
            return name.Trim(); // Loại bỏ khoảng trắng
        }
        // BÀI 1.2
        private static int getOption()
        {
            bool endCheck = false;
            int option = 0;

            while (!endCheck)
            {
                try
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Bài tập buổi 3");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("1. Bài 1");
                    Console.WriteLine("2. Bài 2");
                    Console.WriteLine("3. Bài 3");
                    Console.WriteLine("4. Bài 4");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("---------------------------------------------");
                    Console.Write("Nhập lựa chọn của bạn: ");

                    option = Int32.Parse(Console.ReadLine());

                    if (option >= 0 && option <= 9)
                    {
                        endCheck = true;
                    }
                    else
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Vui lòng chọn một trong các lựa chọn trên!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Vui lòng chọn một trong các lựa chọn trên!");
                }
            }
            return option;
        }

    }

}

