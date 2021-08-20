using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Assignment
{
    public static class SinhVien
    {
        public static Student themSinhVien()
        {
            Student student = new Student();
            student.Name = Helper.GetValue("Nhập tên sinh viên: ");
            student.GioiTinh = Helper.GetValue("Nhập giới tính sinh viên: ");
            student.AgeSinhVien = Convert.ToInt32(Helper.GetValue("Nhập tuổi sinh viên: "));
            student.DiemToan = Convert.ToSingle(Helper.GetValue("Nhập điểm toán của sinh viên: "));
            student.DiemLy = Convert.ToSingle(Helper.GetValue("Nhập điểm lý của sinh viên: "));
            student.DiemHoa = Convert.ToSingle(Helper.GetValue("Nhập điểm hóa của sinh viên: "));
            student.DiemTB = ((student.DiemToan + student.DiemLy + student.DiemHoa) / 3);
            student.IdSinhVien = 0;
            WriteLine("Điểm TB của sinh viên là: " + student.DiemTB);
            if (student.DiemTB >= 8)
                student.HocLuc = "Học sinh giỏi";

            if (student.DiemTB < 8 && student.DiemTB >= 6.5)
                student.HocLuc = "Học sinh khá";

            if (student.DiemTB < 6.5 && student.DiemTB >= 5)
                student.HocLuc = "Học sinh TB";

            if (student.DiemTB < 5)
            {
                student.HocLuc = "Học sinh yếu";
            }
            return student;


        }

        public static int GenerateID(List<Student> students)
        {
            return students.Max(r => r.IdSinhVien) + 1;
        }

        public static int GenerateId(List<Student> students)
        {
            int max = 1;
            if(students!= null && students.Count > 0)
            {
                max = students[0].IdSinhVien;
                foreach (var IdSinhVien in students)
                {
                    if(max < IdSinhVien.IdSinhVien)
                    {
                        max = IdSinhVien.IdSinhVien;
                    }
                }
                max++;
            }
            return max;
        }
        public static int SoLuongSinhVien(List<Student> students)
        {
            int Count = 0;
            if ( students!= null)
            {
                Count = students.Count;
            }
            return Count;
        }

        public static void UpdateSinhVien(List<Student> students)
        {
            WriteLine("\n2. Cập nhật thông tin sinh viên bởi ID.");
            int idSinhVien = Convert.ToInt16(Helper.GetValue("Nhập id sinh viên: "));
            int index = students.FindIndex(x => x.IdSinhVien == idSinhVien);
            if (idSinhVien < 0)
            {
                themSinhVien();
            }
            else
            {
                WriteLine("Không tìm thấy sinh viên nào");
            }

        }

        public static void DeleteSinhVien(List<Student> students)
        {
            int id = int.Parse(Helper.GetValue("Nhập id sinh viên: "));
            int index = students.FindIndex(x => x.IdSinhVien == id);
            if (index > 0)
            {
                students.RemoveAt(index);
                WriteLine("Đã xóa sinh viên");
            }
            else
            {
                WriteLine("Không tìm thấy học sinh!!!");
            }     
        }

       

        public static void SortByDiemTB(List<Student> students)
        {
            students.Sort(delegate (Student student, Student student1)
            {
                return student.DiemTB.CompareTo(student1.DiemTB);
               
               
            });
            
        }

        public static void SortByName(List<Student> students)
        {
            students.Sort(delegate (Student student, Student student1) {
                return student.Name.CompareTo(student1.Name);
            });
        }

        public static void SearchSinhVien()
        {
            bool isValid = false;

            List<Student> searchs = new List<Student>();
            Console.Write("Nhập họ và tên: ");
            string name = Console.ReadLine();
            searchs = searchs.FindAll(x => x.Name.Equals(name));
            if (searchs == null)
            {
                Console.WriteLine("Không tìm thấy học sinh này!");
            }
            else
            {
                isValid = true;
                Console.WriteLine(searchs);

            }
        }

        public static void Printf(List<Student> students)
        {
            foreach (var student in students)
            {
                WriteLine($"{student.Name}\n {student.GioiTinh}\n {student.AgeSinhVien}\n" +
                    $"{student.DiemToan}\n{student.DiemLy}\n{student.DiemHoa}\n{student.DiemTB}\n{student.HocLuc}");

            }
        }

        public static void SortByID(List<Student> students)
        {
            students.Sort(delegate (Student student, Student student1) {
                return student1.IdSinhVien.CompareTo(student1.IdSinhVien);
            });
        }


    }
    public struct Student
    {
        public string Name;
        public string GioiTinh;
        public int IdSinhVien;
        public int AgeSinhVien;
        public float DiemToan;
        public float DiemLy;
        public float DiemHoa;
        public float DiemTB;
        public string HocLuc;

       
    }
}
