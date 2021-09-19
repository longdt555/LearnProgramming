using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_Abstract
{
    public abstract class Abstract
    {
        public abstract string SayHello();  // abstract methods
        public abstract string SayNationality(); // abstract methods

        public string Walk()  //normal methods
        {
            return "Đi bằng 2 chân";
        }
    }
    public class Say : Abstract
    {
        public override string SayHello()
        {
            return $"Hello";
        }

        public override string SayNationality()
        {
            return $"My Country";
        }
    }
    
}
