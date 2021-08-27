using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    class Collection
    {
        public static void App()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Thanh, Than, Thanhhhh, hai
            // == === Th




            var intss = new List<int>();
            // Thuộc tính nâng cao của Collection so với mảng 


            var array = new ArrayList()
            {
                1,2,5,4,3
            }; // _> khởi tại array list rỗng

            ArrayList array2 = new ArrayList(5);

            ArrayList array3 = new ArrayList(array);

            var arrCount = array3.Count;
            //array3.Sort();
            Console.WriteLine($"Before");
            foreach (var item in array3)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine($"Before");
            array3.Sort();
            foreach (var item in array3)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine($"Reverse");
            array3.Reverse();
            foreach (var item in array3)
            {
                Console.WriteLine($"{item}");
            }


            Console.WriteLine($"IndexOf");
            var index = array3.IndexOf(2);
            Console.WriteLine($"{index}");


            // Th: bắt buộc tên phải: Th
            // Th:

            // string1.Contains(string2);

            var array4 = new ArrayList()
            {
                "Thanh", "Than", "Thanhhhhh", "Long"
            };

            foreach (var item in array4)
            {
                if (item.ToString().Contains("Th"))
                {
                    Console.WriteLine("Tìm thấy rồi!");
                }
            }

            var array5 = new ArrayList()
            {
                new Student()
                {
                    Name = "Thanh"
                },
                new Student()
                {
                    Name = "Th"
                }
            };

            foreach (var item in array5)
            {
                var student = (Student)item;
                if (student.Name.Contains("Th"))
                    Console.WriteLine($"Tim Thay Roi");
            }
        }
        public struct Student
        {
            public string Name;
            public int Id;
        }
    }
}
