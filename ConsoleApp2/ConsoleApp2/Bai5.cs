using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Bai5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap Bac Luong cua ban: ");
            long BacLuong = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Nhap Ngay Cong cua ban: ");
            long NgayCong = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Nhap Phu Cap cua ban: ");
            long PhuCap = Convert.ToInt64(Console.ReadLine());


            if (NgayCong <= 2)
            {
                Console.WriteLine("Luong cua ban la:  " + BacLuong * 650000 * (NgayCong * 2) + PhuCap);
            }
            else
            {
                Console.WriteLine("Luong cua ban la: " + BacLuong * 650000 * NgayCong + PhuCap);
            }
        }
    }
}
