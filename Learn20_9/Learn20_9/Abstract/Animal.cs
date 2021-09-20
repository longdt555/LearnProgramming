using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn20_9.Abstract
{
    public abstract class Animal
    {
        public abstract string SayHello(string msg);
        public abstract string SayNationality(string msg);
        public abstract string SayJob(string msg);

        public string CanWalk()
        {
            return $"Walk";
        }
        public string CanEat()
        {
            return $"Eat";
        }
    }
}
