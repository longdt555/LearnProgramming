using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn20_9.Other
{
    class Student : Abstract.Animal
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public float AvgScore { get; set; }
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
        public string Sleep()
        {
            return $"Sleeping";
        }
        public Student()
        {
            Id = GenerateId();
        }
        public Student(string name)
        {
            Name = name;
        }
        public Student(int id)
        {
            Id = id;
        }
        public Student(float avgScore)
        {
            AvgScore = avgScore;
        }
        public Student(string name,int id)
        {
            Name = name;
            Id = id;
        }
        public Student(string name , int id, float avgScore)
        {
            Name = name;
            Id = id;
            AvgScore = avgScore;
        }
        private int GenerateId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
