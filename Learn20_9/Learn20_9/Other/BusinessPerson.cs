using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn20_9.Other
{
    public class BusinessPerson : Abstract.Animal
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
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
        public string Sex(string msg)
        {
            return msg;
        }
        public BusinessPerson()
        {
            Id = GenerateId();
        }
        public BusinessPerson(string name)
        {
            Name = name;
        }
        public BusinessPerson(int id)
        {
            Id = id;
        }
        public BusinessPerson(string name , int id)
        {
            Name = name;
            Id = id;
        }
        public BusinessPerson(string name, int id , int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }
        private int GenerateId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
