using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Dtos.Params
{
    public class KhachHangParam
    {
        public KhachHangParam()
        {

        }
        public KhachHangParam(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
