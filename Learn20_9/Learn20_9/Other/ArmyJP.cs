using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn20_9.Abstract;

namespace Learn20_9.Other
{
    // abstract: is a N
    // interface: can do something
    public class John : ArmyAbstract, WomanInterface, ManInterface
    {
        public override string SayUnit(int unit)
        {
            throw new NotImplementedException();
        }

        public override string TimeSleep()
        {
            throw new NotImplementedException();
        }

        public override string TimeExercise()
        {
            throw new NotImplementedException();
        }

        public string LayVo()
        {
            throw new NotImplementedException();
        }

        public string SayHello()
        {
            throw new NotImplementedException();
        }

        public string DeCon()
        {
            throw new NotImplementedException();
        }
    }
}
