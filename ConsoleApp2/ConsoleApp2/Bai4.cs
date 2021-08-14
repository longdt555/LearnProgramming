using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Bai4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap ho ten ban: ");
            string hoTen = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Nhap " + Tool.diemToan + " cua ban");
            float diemToan = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Nhap " + Tool.diemLy + " cua ban");
            float diemLy = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Nhap " + Tool.diemHoa + " cua ban");
            float diemHoa = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine(hoTen.ToUpper());
            Console.WriteLine(Tool.diemToan + " cua ban la " + diemToan);
            Console.WriteLine(Tool.diemLy + " cua ban la " + diemLy);
            Console.WriteLine(Tool.diemHoa + " cua ban la " + diemHoa);
            Console.WriteLine(Tool.diemTB + " cua ban la " + (diemToan + diemLy + diemHoa) / 3);



        }
    }
}
