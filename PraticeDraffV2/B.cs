using System;
using System.Collections.Generic;
using System.Text;

namespace PraticeDraffV2
{
    public class B
    {
        public static int PublicStatic = 10;

        private static int _private = 10;

        public int Public = 10;
        protected int Protected = 10;
        protected internal int ProtectedInternal = 10;

        public void Void1()
        {

        }
        private void Void2()
        {

        }
    }

    public class A
    {
        public void Print()
        {
            var b = new B();

            var var1 = b.Public;
            b.Void1();
        }
    }
    
}
