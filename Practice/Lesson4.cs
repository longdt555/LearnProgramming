using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Console;
using static Lesson.Common.Helpers.AppHelper;
using Lesson.Common.Enums;

namespace Practice
{
    public static class Lesson4
    {
        // Struct kiểu dữ liệu có cấu trúc (Class), được kết hợp bởi các kiểu dữ liệu nguyên thủy hoặc các kiểu dữ liệu có cấu trúc khác

        /* Quản lý và nhập dữ liệu cho 10 sinh viên có 4 thông tin như sau
             Mã số.
             Họ tên.
             Tuổi
             CMND.
         */
        public static Student AddStudentIntoClass()
        {
            //var student = new Student();
            //student.Id = ConvertStringToInt(GetValueFromKeyBoard("Nhập mã số học sinh: "));
            //student.FullName = GetValueFromKeyBoard("Nhập họ tên học sinh: ");
            //student.Age = ConvertStringToInt(GetValueFromKeyBoard("Nhập tuổi học sinh: "));
            //student.IdentityNum = ConvertStringToInt(GetValueFromKeyBoard("Nhập cmnd học sinh: "));

            var student = new Student
            {
                Id = ConvertStringToInt(GetValueFromKeyBoard("Nhập mã số học sinh: ")),
                FullName = GetValueFromKeyBoard("Nhập họ tên học sinh: "),
                Age = ConvertStringToInt(GetValueFromKeyBoard("Nhập tuổi học sinh: ")),
                IdentityNum = ConvertStringToInt(GetValueFromKeyBoard("Nhập cmnd học sinh: "))
            };
            return student;
        }

        public static void ShowEnum()
        {
            WriteLine((int)Color.RED);
            WriteLine((int)Color.BLUE);
            WriteLine((int)Color.YELLOW);
            WriteLine("--------------");
            WriteLine((int)Color1.RED);
            WriteLine((int)Color1.BLUE);
            WriteLine((int)Color1.YELLOW);
            WriteLine("--------------");
            WriteLine((int)Color2.RED);
            WriteLine((int)Color2.BLUE);
            WriteLine((int)Color2.YELLOW);

            WriteLine("--------------");
            WriteLine((int)Color3.RED);
            WriteLine((int)Color3.BLUE);
            WriteLine((int)Color3.YELLOW);
        }

    }

    public struct Student
    {
        public int Id;
        public string FullName;
        public int Age;
        public int IdentityNum;
    }
}