using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;

namespace Practice
{
    public static class ListInCSharp
    {
        //public static List<Student1> List()
        //{
        //    List<Student1> students = new List<Student1>();

        //    var student = new Student1()
        //    {
        //        Name = "Long"
        //    };

        //    students.Add(student);
        //    return students;
        //}

        public static void Main2()
        {
            // array
            var intss = new int[2]
            {
                1, 2
            };

            // bubble sort

            // collection
            Student1 student; // Khai báo: null
            student = new Student1()
            {
                Id = 10,
                Name = "long"
            }; // Khởi tạo: default - user'svalue define

            var arrayList = new ArrayList()
            {
                1, 2,3,4,5,6, "7", student
            };

            arrayList.Sort();

            arrayList.Add("123");

            // List: generic collections
            var myList = new List<int>() // Generic // Collections
            {
                1, 9
            };
            myList.Add(1);
            myList.Sort();
            myList.Reverse();

            var myList2 = new List<string>();
            var myList3 = new List<Student1>();

            // List<T>



            // => List nâng cấp, thay thế cho Arraylist


            // Dictionary: Dictionary<TKey, TValue>  dicts = new Dictionary<TKey, TValue>();

            var MyHash = new Dictionary<string, string>();
            MyHash.Add("T", "TieuThuyet");
            MyHash.Add("S", "SamCho");

            var MyHash1 = new Dictionary<int, string>();
            MyHash1.Add(1, "TieuThuyet");
            MyHash1.Add(2, "SamCho");

            var MyHash2 = new Dictionary<int, int>();
            MyHash2.Add(1, 1);
            MyHash2.Add(2, 1);


        }

        public static int ConvertValueToInt<T>(T value)
        {
            return Convert.ToInt32(value);
        }


    }

    public class Student1
    {
        public int Id;
        public string Name;
    }
}
