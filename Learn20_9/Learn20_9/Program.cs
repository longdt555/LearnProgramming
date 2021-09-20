using Learn20_9.Other;
using static Learn20_9.Helper.Helper;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Learn20_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //var business = new BusinessPerson();
            //business.Name = GetValue("Nhập tên");
            //Console.WriteLine($"Tên: {business.Name}\nID:{business.Id}\nGiới tính: {business.Sex("Nam")}\nSay Hello: {business.SayHello("Xin Chào")}\n" +
            //    $"Job: {business.SayJob("Business")}\nSay Nationality: {business.SayNationality("Việt Nam")}\n");

            //var student = new Student("John",2,8);
            //Console.WriteLine($"Tên: {student.Name}\nID: {student.Id}\nĐiểm TB: {student.AvgScore}\nSay Hello: {student.SayHello("Hi")}" +
            //    $"\nJob: {student.SayJob("Student")}\nSay Nationality: {student.SayNationality("American")}\n{student.CanWalk()}\n{student.CanEat()}\n{student.Sleep()}\n");

            //var teacher = new Teacher(4, "Grace");
            //Console.WriteLine($"Tên: {teacher.Name}\nID: {teacher.Id}\nSay Hello: {teacher.SayHello("Hello")}" +
            //    $"\nSay Nationality: {teacher.SayNationality("England")}\n{teacher.CanWalk()}\nJob: {teacher.SayJob("Teacher")}" +
            //    $"\n{teacher.ReadBook()}\n");

            //var worker = new Worker("Thomas");
            //worker.Id = 4;
            //Console.WriteLine($"Tên: {worker.Name}\nID: {worker.Id}\nSay Hello: {worker.SayHello("Ní hảo")}" +
            //    $"\nSay Nationality: {worker.SayNationality("China")}\n{worker.CanWalk()}\nJob: {worker.SayJob("Worker")}" +
            //    $"\n{worker.Work()}\n");

            var jonh = new ArmyUs();
            Console.WriteLine(jonh.SayHello("Hello"));
            Console.WriteLine(jonh.SayUnit(15));
            Console.WriteLine(jonh.TimeSleep());
            Console.WriteLine(jonh.TimeExercise());

            var hai = new ArmyVn();
            Console.WriteLine(hai.SayHello("XinChao"));
            Console.WriteLine(hai.SayUnit(15));
            Console.WriteLine(hai.TimeSleep());
            Console.WriteLine(hai.TimeExercise());

            var tokuda = new ArmyJp();
            Console.WriteLine(tokuda.SayUnit(15));
            Console.WriteLine(tokuda.TimeSleep());
            Console.WriteLine(tokuda.ExerciseTime());

        }
    }
}
