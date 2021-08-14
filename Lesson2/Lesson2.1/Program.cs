using System;

namespace Lesson2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //bai1

            Console.WriteLine("Nhap 3 so de so sanh: ");
            int so1 = Convert.ToInt32(Console.ReadLine());
            int so2 = Convert.ToInt32(Console.ReadLine());
            int so3 = Convert.ToInt32(Console.ReadLine());

            if (so1 > so2 && so1 > so3)
            {
                Console.WriteLine(so1 + " la so lon nhat");
            }
            else if (so2 > so1 && so2 > so3)
            {
                Console.WriteLine(so2 + " la so lon nhat");
            }
            else
            {
                Console.WriteLine(so3 + " la so lon nhat");
            }

            //bai2 

            Console.WriteLine("Nhap ho va ten cua ban: ");
            string fullName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Nhap diem cua ban: ");
            float point = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Hello " + fullName.ToUpper());
            if (point >= 8)
            {
                Console.WriteLine(Tool.HSG);
            }
            else if (point < 8 || point >= 6.5)
            {
                Console.WriteLine(Tool.HSK);
            }
            else if (point < 6.5 || point >= 5)
            {
                Console.WriteLine(Tool.HSTB);
            }
            else
            {
                Console.WriteLine(Tool.HSY);
            }

            //bai3 

            Console.WriteLine("Nhap vao b1: ");
            float b1 = Convert.ToSingle(Console.ReadLine());

            if (b1 == 0)
            {
                Console.WriteLine("b1 phai khac 0");
            }
            else
            {
                Console.WriteLine("Nhap vao c1: ");
                float c1 = Convert.ToSingle(Console.ReadLine());

                float x = -c1 / b1;
                Console.WriteLine("{0}x + {1} = 0 \n=> x = {2}", b1, c1, x);
            }

            //bai4

            int a, b, c;
            Console.WriteLine("Nhap vao a, b, c");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            float delta = b * b - 4 * a * c;
            if (delta > 0)
            {
                double x1 = ((-1) * b + Math.Sqrt(delta)) / (2 * a);
                double x2 = ((-1) * b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Nghiem x1 = {0}, x2 = {1}", x1, x2);
            }
            else if (delta == 0)
            {
                double x1 = (-1 * b) / (2 * a);
                Console.WriteLine("Nghiem kep x1 = {0}", x1);
            }
            else
            {
                Console.WriteLine("Vo Nghiem");
            }

            //bai5 

            Console.WriteLine("Hay nhap vao 1 so am");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number < 0)
            {
                for (int i = number; i <= 1; i++)
                {

                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("Hay nhap 1 so am");
            }

            //bai6

            
            Console.Write("Kiem tra so nguyen to trong C#:\n");
            int number1;
            int bien_dem = 0;

            Console.Write("Nhap mot so bat ky: ");
            number1 = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= number1; i++)
                if (number1 % i == 0)
                    bien_dem++;

            if (bien_dem == 2)
                Console.WriteLine(number1 +" la so nguyen to.");
            else
                Console.WriteLine(number1 + " khong phai la so nguyen to.");

            //bai7

            Console.WriteLine("Chuong trinh kiem tra nam nhuan");
            Console.WriteLine("Nhap nam ban muon kiem tra");
            int year = Convert.ToInt32(Console.ReadLine());
            if (year % 400 == 0)
                Console.WriteLine(year + " la nam nhuan");
            else if (year % 100 == 0)
                Console.WriteLine(year + " khong la nam nhuan");
            else if (year % 4 == 0)
                Console.WriteLine(year + " la nam nhuan");
            else
                Console.WriteLine(year + " khong la nam nhuan");


            //bai8


            //bai9
            Console.WriteLine("Hay nhap 1 so nguyen duong: ");
            int number2 = Convert.ToInt32(Console.ReadLine());
            int sum = default;
            int boDem = default;

            if (number2 < 0)
                Console.WriteLine("Hay nhap vao 1 so nguyen duong");
            else
            {
                for (int i = 1; i <= number2 ; i++)
                {
                    Console.WriteLine(i);
                    sum += i;
                    boDem++;
                   
                }
                Console.WriteLine("Tong cua " + number2 + " la " + sum);
                Console.WriteLine("Trung binh cong cua " + number2 + " la " + sum/boDem);
            }





        }
    }
}
