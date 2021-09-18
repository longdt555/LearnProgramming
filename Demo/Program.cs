using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;

            var test = new TestAbstract();

            test.SayHelloAbstract();

            test.SayHelloAbstractV2();
        }

        public static void StudentInitial()
        {
            // Khai báo: giá trị null
            // Khởi tạo: giá trị của thành phần lấy giá trị mặc định của kiểu dữ liệu

            var hobbies = new List<string>()
            {
                "playing football",
                "watching tv"
            };
            var student1 = new Student { Name = "Long", Grade = 8, Class = "8A" }; // khởi tạo


            var des1 = student1.StudyDestination("Trường cấp 2");
            student1.Hobbies = hobbies;


            var student4 = new Student();


            var student3 = new Student(10);
            //var nameLength = student3.Name.Length;
            //var totalHobby1 = hobbies.Count; // error


            string totalHobby; // Khai báo: null
            
            totalHobby = student3.Hobbies.Count.ToString(); // "" => 0


            var student2 = new Student { Name = "Hai", Grade = 4, Class = "4A" };
            var des2 = student2.StudyDestination("Trường cấp 1");

            WriteLine($"Student1: {student1.Id}, {student1.Name}, {student1.Grade}, {student1.Class}, {des1}");
            WriteLine($"Student2: {student2.Id}, {student2.Name}, {student2.Grade}, {student2.Class}, {des2}");
        }
    }
}