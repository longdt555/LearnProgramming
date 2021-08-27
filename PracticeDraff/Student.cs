using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PracticeDraff
{
    public class Student
    {
        public float Id { get; set; }
        public string Amount { get; set; }
        public string Name { get; set; }

        public int GetAvgScore()
        {
            Helpers.ConvertStringToInt(Amount);

            Helpers.ConvertFloatToInt(Id);

            // generic 

            Helpers.ConvertValueToInt(Amount);
            Helpers.ConvertValueToInt(Id);
            Helpers.ConvertValueToInt(Name);

            return 0;
        }
        
    }
}
