using System;
using System.Text;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Green;


            while (true)
            {
                WriteLine("\nCHƯƠNG TRÌNH QUẢN LÍ ĐẦU SÁCH TRONG C#\a");
                WriteLine("=========================MENU==========================");
                WriteLine("**  1. Thêm đầu sách.                                **");
                WriteLine("**  2. Cập nhật thông tin đầu sách theo ID.          **");
                WriteLine("**  3. Xóa đầu sách theo ID.                         **");
                WriteLine("**  4. Tìm kiếm đầu sách theo tên.                   **");
                WriteLine("**  5. Sắp xếp đầu sách theo giá bán.                **");
                WriteLine("**  6. Sắp xếp đầu sách theo tên.                    **");
                WriteLine("**  7. Sắp xếp đầu sách theo ID.                     **");
                WriteLine("**  8. Hiển thị danh sách đầu sách.                  **");
                WriteLine("**  9. Đối với mỗi một đầu sách hãy tự động định     ** \n" +
                          "**  nghĩa nhưng hàm chỉ riêng đầu sách đó mới có.    **");
                WriteLine("**  0. Thoát                                         **");
                WriteLine("=======================================================");
                Write("Nhập tùy chọn: ");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        WriteLine("1. Thêm đầu sách.");

                        break;

                    case 2:
                        WriteLine("2. Cập nhật thông tin đầu sách theo ID.");
                        break;


                    case 3:
                        WriteLine("3. Xóa đầu sách theo ID.");
                        break;

                    case 4:
                        WriteLine("4. Tìm kiếm đầu sách theo tên.");
                        break;

                    case 5:
                        WriteLine("5. Sắp xếp đầu sách theo giá bán.");
                        break;

                    case 6:
                        WriteLine("6. Sắp xếp đầu sách theo tên.");
                        break;

                    case 7:
                        WriteLine("7. Sắp xếp đầu sách theo ID.");
                        break;

                    case 8:
                        WriteLine("8. Hiển thị danh sách đầu sách.");
                        break;

                    case 9:
                        WriteLine("9. Đối với mỗi một đầu sách hãy tự động định \n" +
                            " nghĩa nhưng hàm chỉ riêng đầu sách đó mới có.");
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

