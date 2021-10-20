using QuanLyTruongHoc.Helper;
using QuanLyTruongHoc.Services;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static QuanLyTruongHoc.Helper.Helper;
using QuanLyTruongHoc.IServices;

namespace QuanLyTruongHoc
{
    class Program
    {
        static void Main(string[] args)
        {
        EnterOption: try
            {
                while (true)
                {
                    Console.WriteLine("\nCÁC CHỨC NĂNG \a");
                    Console.WriteLine("=========================CHỌN BẢNG CẦN THAO TÁC==========================");
                    Console.WriteLine("**  1.Sinh Viên                            **");
                    Console.WriteLine("**  2.Giáo Viên                            **");
                    Console.WriteLine("**  3.Lớp Học                              **");
                    Console.WriteLine("**  0.Thoát                                **");
                    int key = ConvertToInt(GetValue("Nhập tùy chọn"));
                    switch (key)
                    {
                        case 1:
                            Console.WriteLine("Chọn chức năng !");
                            Console.WriteLine("1. Thêm ");
                            Console.WriteLine("2. Sửa");
                            Console.WriteLine("3. Xóa");
                            int case1 = ConvertToInt(GetValue("Nhập lựa chọn"));
                            switch (case1)
                            {
                                case 1:
                                    Student.GetValueFromUser();
                                    break;
                                case 2:
                                    Student.UpdateFromUser();
                                    break;
                                case 3:
                                    Student.DeleteFromUser();
                                    break;
                            }

                            break;
                        case 2:
                            Console.WriteLine("Chọn chức năng !");
                            Console.WriteLine("1. Thêm ");
                            Console.WriteLine("2. Sửa");
                            Console.WriteLine("3. Xóa");
                            int case2 = ConvertToInt(GetValue("Nhập lựa chọn"));
                            switch (case2)
                            {
                                case 1:
                                    Teacher.GetValueFromUser();
                                    break;
                                case 2:
                                    Teacher.UpdateFromUser();
                                    break;
                                case 3:
                                    Teacher.DeleteFromUser();
                                    break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Chọn chức năng !");
                            Console.WriteLine("1. Thêm ");
                            Console.WriteLine("2. Sửa");
                            Console.WriteLine("3. Xóa");
                            int case3 = ConvertToInt(GetValue("Nhập lựa chọn"));
                            switch (case3)
                            {
                                case 1:
                                    Class.GetValueFromUser();
                                    break;
                                case 2:
                                    Class.UpdateFromUser();
                                    break;
                                case 3:
                                    Class.DeleteFromUser();
                                    break;
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
            catch (Exception)
            {
                Console.WriteLine("Hãy nhập số !!!");
                goto EnterOption;
            }

        }
    }
}







