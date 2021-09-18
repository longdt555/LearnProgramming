using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PracticeDraff
{
    public class Student
    {
        public float Id { get; set; }
        public string DiemToan { get; set; }
        public string Name { get; set; }
        public string Khoi { get; set; }
        public int GetAvgScore()
        {
            //Helpers.ConvertStringToInt(Amount);

            //Helpers.ConvertFloatToInt(Id);

            //// generic 

            //Helpers.ConvertValueToInt(Amount);
            //Helpers.ConvertValueToInt(Id);
            //Helpers.ConvertValueToInt(Name);

            return 0;
        }
        
    }

    public class Person
    {
        public float Id { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
    }
}
