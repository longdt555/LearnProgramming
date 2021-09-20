using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn20_9.Other;

namespace Learn20_9.Abstract
{
    public class Management
    {
        public List<Person> Data { get; set; }

        public Management()
        {
            Data = new List<Person>();
        }

        public int GetTotal()
        {
            return Data.Count;
        }

        public string SayHello()
        {
            return $"Hello";

        }

        public string SayHello(int a)
        {
            return $"Hello";
        }
    }
}
