using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Dtos.Params
{
    public class AccountParam
    {
        public AccountParam()
        {

        }
        public AccountParam(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
