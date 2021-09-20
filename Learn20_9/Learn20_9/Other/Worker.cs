using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn20_9.Other
{
    class Worker : Abstract.Animal
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
        public string Work()
        {
            return $"Working";
        }
        public Worker()
        {
            Id = GenerateId();
        }
        public Worker(string name)
        {
            Name = name;
        }
        public Worker(int id)
        {
            Id = id;
        }
        public Worker(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public Worker(int id, string name)
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
