using System;

namespace Lesson1_Bai5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap Bac Luong cua ban: ");
            long BacLuong = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Nhap Ngay Cong cua ban: ");
            long NgayCong = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Nhap Phu Cap cua ban: ");
            long PhuCap = Convert.ToInt64(Console.ReadLine());

            long TienLanh = BacLuong * 650000;


            if (NgayCong <= 2)
            {
                Console.WriteLine("Luong cua ban la:  " + TienLanh * (NgayCong * 2) + PhuCap);
            }
            else
            {
                Console.WriteLine("Luong cua ban la: " + TienLanh * NgayCong + PhuCap);
            }



        }
    }
}
