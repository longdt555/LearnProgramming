using System;
using System.Text;
using static System.Console;
using System.Linq;
using System.Collections.Generic;
using static Assignment.SinhVien;

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

            EnterOption: try
            {
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

                            var student = themSinhVien(); // Tạo ra sinh viên
                            student.IdSinhVien = GenerateId(students); // Cập nhật id cho sinh viên đó là unique

                            students.Add(student); // Thêm sinh viên đó vào danh sách sinh viên
                            WriteLine("\nThêm sinh viên thành công!");

                            break;
                            // theo code này: sửa cho n chạy đúng luồng
                        //  -> cách khác giải quyết khác -> 
                        case 2:
                            WriteLine("2. Cập nhật thông tin sinh viên bởi ID. ");
                            int id = Convert.ToInt32(Helper.GetValue("Nhập id sinh viên: "));
                            var studentFound = students.Find(x => x.IdSinhVien == id);
                            UpdateSinhVien(ref studentFound);
                            var index = students.FindIndex(x => x.IdSinhVien == studentFound.IdSinhVien);
                            students[index] = studentFound;

                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("Sửa thành công!");

                            //string[] students2 = new string[5]
                            //{
                            //    "A","B", "C", "D","E"
                            //};

                            ////var student = new string(); => Vùng nhớ mới,
                            ////có giá trị giống như giá trị của phần tử như 1 trong Mảng Student

                            //var studentTemp = students2[1]; 
                            //studentTemp = "b";

                            //students2[1] = studentTemp;
                            //// students2[1] => changed ????????
                            //Console.WriteLine($"{students2[1]}");
                            break;


                        case 3:
                            WriteLine("3. Xóa sinh viên bởi ID.");
                            DeleteSinhVien(students);
                            break;

                        case 4:
                            WriteLine("4. Tìm kiếm sinh viên theo tên. ");
                            SearchSinhVien(students);
                            break;

                        case 5:
                            WriteLine("5. Sắp xếp sinh viên theo điểm trung bình (GPA).");
                            SortByDiemTB(students);
                            Printf(students);
                            break;

                        case 6:
                            WriteLine("6. Sắp xếp sinh viên theo tên.");
                            SortByName(students);
                            Printf(students);
                            break;

                        case 7:
                            WriteLine("7. Sắp xếp sinh viên theo ID.");
                            SortByID(students);
                            Printf(students);
                            break;

                        case 8:
                            WriteLine("\n8. Hiển thị danh sách sinh viên.");
                            if (students.Count() > 0)
                            {
                                Printf(students);
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
            }
            catch (Exception a)
            {
                WriteLine("Hãy nhập số !!!");
                goto EnterOption;
            }
        }
    }
}
