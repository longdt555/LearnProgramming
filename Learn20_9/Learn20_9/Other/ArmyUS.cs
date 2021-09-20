using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn20_9.Abstract;

namespace Learn20_9.Other
{
    // Thuộc trung đội 18: Chiến binh loại giỏi
    // Thuộc trung đội 15: Chiến binh loại khá
    // Khác: chiến binh bình thường
    public class ArmyUs: Management
    {
        public string SayUnit(int unit)
        {
            if (unit > 18)
            {
                return " Chiến binh loại giỏi";
            }
            if (unit >= 15 && unit <= 18)
            {
                return "Chiến binh loại khá";
            }
            return "Trung đội bình thường";
        }

        public string TimeSleep()
        {
            return "22h";
        }

        public string TimeExercise()
        {
            return "5h";
        }
    }
}
