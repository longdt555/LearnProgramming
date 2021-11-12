using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Dtos.Params
{
    public class LoaiParam
    {
        public LoaiParam()
        {

        }
        public LoaiParam(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
