using System;
using static System.Console;
using static Learn10_9.Helper;
using static Learn10_9.Common;
using System.Text;

namespace Learn10_9
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Yellow;

            while (true)
            {
                WriteLine("1. Thêm đầu sách");
                WriteLine("2. Sửa sách theo key");
                WriteLine("3. Xóa sách theo key");
                WriteLine("4. Hiện thị danh sách");
                WriteLine("0. Thoát");
                int option = ConvertToInt(GetValue("Nhập lựa chọn của bạn"));
                switch (option)
                {
                    case 1:
                        AddSach();
                        WriteLine("Thêm thành công !\n");
                        break;
                    case 2:
                        EditByKey();
                        AddSach();
                        WriteLine("Sửa thành công !\n");
                        break;
                    case 3:
                        DeleteByKey();
                        WriteLine("Xóa thành công !\n");
                        break;
                    case 4:
                        Print();
                        break;

                    case 0:
                        Console.WriteLine("\nBạn đã chọn thoát chương trình!");
                        return;
                    default:
                        Console.WriteLine("\nKhông có chức năng này!");
                        Console.WriteLine("\nHãy chọn chức năng trong hộp menu.");
                        break;
                }
            }

        }
    }
}
