using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeDraff
{

    public class Animal
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Animal GetAnimalById(Animal[] animals, string id)
        {
            var idInt = Convert.ToInt32(id);
            return animals[idInt];
        }

        public int Total(Animal[] animals)
        {
            return animals.Length;
        }
    }
}
