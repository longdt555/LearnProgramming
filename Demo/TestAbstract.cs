using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class TestAbstract : Abstract
    {
        public override void SayHelloAbstract()
        {
            Console.WriteLine("abc");
        }

        public override string SayHelloAbstractV2()
        {
            throw new NotImplementedException();
        }
    }
}
