using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn20_9.Abstract;

namespace Learn20_9.Other
{
    public class ArmyVn : ArmyAbstract, WomanAbstract, ManAbstract
    {
        public override string SayUnit(int unit)
        {
            if (unit == 12)
            {
                return "Trung đội giỏi";
            }

            return "Trung đội bình thường";
        }

        public override string TimeSleep()
        {
            return "21h";
        }

        public override string TimeExercise()
        {
            return "6h";
        }
        
    }
}
