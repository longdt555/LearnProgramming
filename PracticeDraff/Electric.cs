using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeDraff
{
    public class Electric
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float FloatValue { get; set; }

        public int GetValue()
        {
            // Tái sử dụng code
            Helpers.ConvertStringToInt(Id);
            Helpers.ConvertFloatToInt(FloatValue);
            return 0;
        }
    }
}
