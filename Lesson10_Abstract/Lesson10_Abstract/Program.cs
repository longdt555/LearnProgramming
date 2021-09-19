using System;
using static Lesson10_Abstract.Abstract;
using static Lesson10_Abstract.Persons;
using static Lesson10_Abstract.Helper;
using System.Collections.Generic;
using System.Text;


namespace Lesson10_Abstract
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Random random = new Random(); // hàm tạo id random
            int id = random.Next(1, 10);

            var persons = new Persons();


            persons.Name = GetValue("Nhập tên của bạn"); // nhập tên

            var hobbies = new List<string>()
            {
                GetValue("Nhập sở thích của bạn cách nhau bởi dấu phẩy").Trim().Replace(" ","")
            };

            string str = string.Empty;
            foreach (var item in hobbies)
                str = str + item + "," + " ";
            str.Remove(str.Length - 1);

            persons.Hobbies = hobbies;
            persons.Id = id;

            Console.WriteLine($"ID của bạn: {persons.Id}\nTên của bạn: {persons.Name}");
            foreach (var item in hobbies)
            {
                Console.WriteLine($"Sở thích của bạn là: {item}");
            }

            var say = new Say();
            Console.WriteLine($"{say.SayHello()}\n{say.SayNationality()}\n{say.Walk()}");

        }
    }
}
