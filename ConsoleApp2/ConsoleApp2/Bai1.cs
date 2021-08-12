using System;

namespace ConsoleApp2
{
    class Bai1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao so n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(n + " la " + (n % 2 == 0 ? Tool.soChan : Tool.soLe ));
            Console.WriteLine(n + " la " + (n > 0 ? Tool.soDuong : Tool.soAm));


        }
    }
}
