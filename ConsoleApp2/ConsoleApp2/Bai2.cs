using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Bai2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap chieu dai va chieu rong hinh chu nhat: ");
            float chieuDai = Convert.ToSingle(Console.ReadLine());
            float chieuRong = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Chu vi hinh chu nhat la: " + 2 * (chieuDai + chieuRong));
            Console.WriteLine("Dien tich hinh chu nhat la: " + chieuDai * chieuRong);

        }
    }
}
