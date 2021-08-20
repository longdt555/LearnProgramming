using System;
using System.Text;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Yellow;
            //  id, tên, giới tính, tuổi, điểm toán, điểm lý, điểm hóa, điểm trung bình và học lực.

            var students = new List<Student>();

            EnterOption: try {
                while (true)
                {
                    Console.WriteLine("\nCHƯƠNG TRÌNH QUẢN LÍ SINH VIÊN\a");
                    Console.WriteLine("=========================MENU==========================");
                    Console.WriteLine("**  1. Thêm sinh viên.                               **");
                    Console.WriteLine("**  2. Cập nhật thông tin sinh viên bởi ID.          **");
                    Console.WriteLine("**  3. Xóa sinh viên bởi ID.                         **");
                    Console.WriteLine("**  4. Tìm kiếm sinh viên theo tên.                  **");
                    Console.WriteLine("**  5. Sắp xếp sinh viên theo điểm trung bình (GPA). **");
                    Console.WriteLine("**  6. Sắp xếp sinh viên theo tên.                   **");
                    Console.WriteLine("**  7. Sắp xếp sinh viên theo ID.                    **");
                    Console.WriteLine("**  8. Hiển thị danh sách sinh viên.                 **");
                    Console.WriteLine("**  0. Thoát                                         **");
                    Console.WriteLine("=======================================================");
                    Console.Write("Nhập tùy chọn: ");
                    int key = Convert.ToInt32(Console.ReadLine());
                     switch (key)
                    {
                        case 1:
                            WriteLine("\n1. Thêm sinh viên.");

                            var student = SinhVien.themSinhVien(); // Tạo ra sinh viên
                            student.IdSinhVien = SinhVien.GenerateId(students); // Cập nhật id cho sinh viên đó là unique

                            students.Add(student); // Thêm sinh viên đó vào danh sách sinh viên
                            WriteLine("\nThêm sinh viên thành công!");

                            break;

                        case 2:
                            SinhVien.UpdateSinhVien(students);
                            break;

                        case 3:
                            SinhVien.DeleteSinhVien(students);
                            break;

                        case 4:
                            SinhVien.SearchSinhVien();
                            SinhVien.Printf(students);
                            break;

                        case 5:
                            SinhVien.SortByDiemTB(students);
                            SinhVien.Printf(students);
                            break;

                        case 6:
                            SinhVien.SortByName(students);
                            SinhVien.Printf(students);
                            break;

                        case 7:
                            SinhVien.SortByID(students);
                            SinhVien.Printf(students);
                            break;

                        case 8:
                            WriteLine("\n8. Hiển thị danh sách sinh viên.");
                            if (students.Count() > 0)
                            {
                                SinhVien.Printf(students);
                            }
                            else
                            {
                                WriteLine("Chưa có phần tử nào!");
                            }
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
            }catch(Exception a)
            {
                WriteLine("Hãy nhập số !!!");
                goto EnterOption;
            }

        }




    }


}
