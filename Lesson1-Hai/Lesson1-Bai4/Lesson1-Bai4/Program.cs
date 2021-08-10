using System;

namespace Lesson1_Bai4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap Ho Ten ban: ");
            string fullName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Nhap diem Toan cua ban: ");
            float diemToan = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Nhap diem Ly cua ban: ");
            float diemLy = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Nhap diem Hoa cua ban: ");
            float diemHoa = Convert.ToSingle(Console.ReadLine());

            float diemTB = (diemToan + diemLy + diemHoa) / 3;

            Console.WriteLine("Hello " + fullName);
            Console.WriteLine("Diem TB cua ban la: " + diemTB);


        }
    }
}
