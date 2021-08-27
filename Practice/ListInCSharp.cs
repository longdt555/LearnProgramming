using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    public static class ListInCSharp
    {
        public static List<Student1> List()
        {
            List<Student1> students = new List<Student1>();

            var student = new Student1()
            {
                Name = "Long"
            };

            students.Add(student);
            return students;
        }

    }

    public struct Student1
    {
        public int Id;
        public string Name;
    }
}
