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
                Printf(students);
                Student student = new Student();
                int id = Convert.ToInt32(Helper.GetValue("Nhập id sinh viên: "));
                students.Find(x => x.IdSinhVien == id);
                students.Remove(student);
                if(students == null)
                {
                    WriteLine("Không tìm thấy học sinh này!");
                }
                else
                { 
                    Write("Nhập họ tên: ");
                    student.Name = Console.ReadLine();
                    student.GioiTinh = Helper.GetValue("Nhập giới tính: ");
                    student.AgeSinhVien = Convert.ToInt32(Helper.GetValue("Nhập tuổi: "));
                    student.DiemToan = Convert.ToSingle(Helper.GetValue("Nhập điểm toán: "));
                    student.DiemLy = Convert.ToSingle(Helper.GetValue("Nhập điểm lý: "));
                    student.DiemHoa = Convert.ToSingle(Helper.GetValue("Nhập điểm hóa: "));
                }
            
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Sửa thành công!");
            Printf(students);

        }
       
        public static void SearchSinhVien(List<Student> students)
        {
            List<Student> student = new List<Student>();
            string name = Helper.GetValue("Nhập tên sinh viên: ");
            student = students.FindAll(x => x.Name.Contains(name));
            if (student != null)
            {
                Printf(student);
                WriteLine("Tìm thấy rồi!");
            }
            else
            {
                WriteLine("Không tìm thấy học sinh này!");
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

        

        public static void Printf(List<Student> students)
        {
            foreach (var student in students)
            {
                WriteLine($"{student.IdSinhVien}\t{student.Name}\t {student.GioiTinh}\t {student.AgeSinhVien}\t" +
                    $"{student.DiemToan}\t{student.DiemLy}\t{student.DiemHoa}\t{student.DiemTB}\t{student.HocLuc}");

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
