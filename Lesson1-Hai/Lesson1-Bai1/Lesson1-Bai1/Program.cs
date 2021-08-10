using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            string soLe = " va la So Le";
            string soChan = " va la So Chan";
            string soAm = " va la So Am";
            string soDuong = " va la So Duong";

            Console.WriteLine("Nhap 1 so n bat ki: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n > 0 && n % 2 == 0)
            {
                Console.WriteLine("Day la " + soChan + soDuong);
            }
            else if (n > 0 && n % 2 == 1)
            {
                Console.WriteLine("Day la " + soLe + soDuong);
            }
            else if (n < 0 && n % 2 == 0)
            {
                Console.WriteLine("Day la " + soChan + soAm);

            }
            else if (n < 0 && n % 2 == 1)
            {
                Console.WriteLine("Day la " + soLe + soAm);
            }

        }
    }
}
