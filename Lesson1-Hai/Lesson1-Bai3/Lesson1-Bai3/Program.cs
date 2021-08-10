using System;

namespace Lesson1_Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap mot canh cua hinh vuong: ");
            int canhA = Convert.ToInt32(Console.ReadLine());


            int P = canhA * 4;
            int S = canhA * canhA;

            Console.WriteLine("Chu vi hinh vuong la: " + P);
            Console.WriteLine("Dien tich hinh vuong la: " + S);


        }
    }
}
