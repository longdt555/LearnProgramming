using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Bai3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap mot canh cua hinh vuong: ");
            int canhA = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Chu vi hinh vuong la: " + canhA * 4 );
            Console.WriteLine("Dien tich hinh vuong la: " + canhA * canhA);
        }
    }
}
