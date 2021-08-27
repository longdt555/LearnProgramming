using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeDraff
{
    public class Flat
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public Flat GetFlatById(Flat[] students, double id)
        {
            var idInt = Convert.ToInt32(id);
            return students[idInt];
        }

        public int Total(Flat[] students)
        {
            return students.Length;
        }
        // getall, getByName, Sort, Reverse, ..... 20 functions
    }
}
