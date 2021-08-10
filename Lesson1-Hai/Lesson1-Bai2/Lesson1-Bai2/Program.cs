using System;

namespace Lesson1_Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap chieu dai va chieu rong cua hinh chu nhat");
            int length = Convert.ToInt32(Console.ReadLine());
            int width = Convert.ToInt32(Console.ReadLine());

            int P = 2 * (length + width);
            int S = length * width;

            Console.WriteLine("Chu vi hinh chu nhat la: " + P);
            Console.WriteLine("Dien tich hinh chu nhat la: " + S);



        }
    }
}
