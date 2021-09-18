using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class Student
    {
        public Student()
        {
            Hobbies = new List<string>();
            Grade = 1;
            Class = "1A";
        }

        public Student(int id)
        {
            Id = id;
        }
        // Declare

        #region [properties]

        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public string Class { get; set; }
        public List<string> Hobbies { get; set; } // generic collection
        #endregion [properties]


        #region [actions]

        public string StudyDestination(string destination)
        {
            return $"Destination: {destination}";
        }

        #endregion [actions]
    }
}
