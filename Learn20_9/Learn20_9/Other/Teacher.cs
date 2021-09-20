using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn20_9.Other
{
    class Teacher : Abstract.Animal
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public override string SayHello(string msg)
        {
            return msg;
        }

        public override string SayJob(string msg)
        {
            return msg;
        }

        public override string SayNationality(string msg)
        {
            return msg;
        }
        public string ReadBook()
        {
            return $"ReadBook";
        }
        public Teacher()
        {
            Id = GenerateId();
        }
        public Teacher(string name)
        {
            Name = name;
        }
        public Teacher(int id)
        {
            Id = id;
        }
        public Teacher(string name , int id)
        {
            Name = name;
            Id = id;
        }
        public Teacher(int id , string name)
        {
            Id = id; 
            Name = name;
        }
        private int GenerateId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
