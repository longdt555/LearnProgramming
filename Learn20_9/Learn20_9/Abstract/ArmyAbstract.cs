using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn20_9.Abstract
{
    public abstract class ArmyAbstract
    {
        // Quân đội
        public abstract string SayUnit(int unit);
        public abstract string TimeSleep();
        public abstract string TimeExercise();

        public string SayHello(string msg)
        {
            return $"{msg}";

        }
    }
}
