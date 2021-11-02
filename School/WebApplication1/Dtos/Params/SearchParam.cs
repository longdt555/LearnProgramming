using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Dtos.Params
{
    public class SearchParam<T>
    {
        public int PageIndex { get; set; }
        public int PagingSize { get; set; }
        public T Filter { get; set; }


    }
}
