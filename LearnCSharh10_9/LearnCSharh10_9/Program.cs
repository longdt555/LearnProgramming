using System;
using System.Text;
using static System.Console;
using System.Linq;
using static LearnCSharh10_9.Helper;
using static LearnCSharh10_9.SinhVienData;
using System.Collections.Generic;

namespace LearnCSharh10_9
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Yellow;

            var sinhVien = new List<SinhVien>();
            var sinhVienn = new SinhVienData();
        EnterOption: try
            {
                while (true)
                {
                    WriteLine("\nCHƯƠNG TRÌNH QUẢN LÍ SINH VIÊN\a");
                    WriteLine("=========================MENU==========================");
                    WriteLine("**  1. Thêm sinh viên.                               **");
                    WriteLine("**  2. Cập nhật thông tin sinh viên bởi ID.          **");
                    WriteLine("**  3. Xóa sinh viên bởi ID.                         **");
                    WriteLine("**  4. Tìm kiếm sinh viên theo tên.                  **");
                    WriteLine("**  5. Sắp xếp sinh viên theo điểm trung bình (GPA). **");
                    WriteLine("**  6. Sắp xếp sinh viên theo tên.                   **");
                    WriteLine("**  7. Sắp xếp sinh viên theo ID.                    **");
                    WriteLine("**  8. Hiển thị danh sách sinh viên.                 **");
                    WriteLine("**  0. Thoát                                         **");
                    WriteLine("=======================================================");
                    Write("Nhập tùy chọn: ");
                    int key = Convert.ToInt32(ReadLine());
                    switch (key)
                    {
                        case 1:
                            WriteLine("1. Thêm sinh viên.");
                            sinhVienn.Add(sinhVien);
                            break;
                        case 2:
                            WriteLine("2. Cập nhật thông tin sinh viên bởi ID.");
                            int idcase2 = ConvertToInt(GetValue("Nhập ID của sinh viên"));
                            sinhVienn.Update(sinhVien, idcase2);
                            break;
                        case 3:
                            WriteLine("3. Xóa sinh viên bởi ID.");
                            int idcase3 = ConvertToInt(GetValue("Nhập ID của sinh viên"));
                            sinhVienn.Delete(sinhVien, idcase3);
                            break;
                        case 4:
                            WriteLine("4. Tìm kiếm sinh viên theo tên.");
                            string namecase4 = GetValue("Nhập tên sinh viên");
                            sinhVienn.Print(sinhVienn.SearchName(sinhVien, namecase4));
                            break;
                        case 5:
                            WriteLine("5. Sắp xếp sinh viên theo điểm trung bình (GPA).");
                            WriteLine("1. Sắp xếp tăng dần");
                            WriteLine("2. Sắp xếp giảm dần");
                            int case5 = ConvertToInt(GetValue("Vui lòng chọn"));
                            switch (case5)
                            {
                                case 1:
                                    sinhVienn.Print(sinhVienn.SortByAvgScore(sinhVien, SortCondition.Esc));
                                    break;
                                case 2:
                                    sinhVienn.Print(sinhVienn.SortByAvgScore(sinhVien, SortCondition.Desc));
                                    break;
                                default:
                                    WriteLine("Vui lòng chọn hợp lệ !");
                                    break;
                            }
                            break;
                        case 6:
                            WriteLine("6. Sắp xếp sinh viên theo tên.");
                            sinhVienn.Print(sinhVienn.SortByName(sinhVien));
                            break;
                        case 7:
                            WriteLine("7. Sắp xếp sinh viên theo ID.");
                            sinhVienn.Print(sinhVienn.SortById(sinhVien));
                            break;
                        case 8:
                            WriteLine("8. Hiển thị danh sách sinh viên.");
                            sinhVienn.Print(sinhVien);
                            break;
                        case 0:
                            WriteLine("\nBạn đã chọn thoát chương trình!");
                            return;
                        default:
                            WriteLine("\nKhông có chức năng này!");
                            WriteLine("\nHãy chọn chức năng trong hộp menu.");
                            break;
                    }

                }

            }
            catch (Exception)
            {
                WriteLine("Hãy nhập số !!!");
                goto EnterOption;
            }
        }
    }
}
