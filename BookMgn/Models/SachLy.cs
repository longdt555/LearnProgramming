using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMgn
{
    public class SachLy
    {
        public string SachVanDif { get; set; }
        public string Id { get; set; }
        public SachLy Add(SachLy model)
        {
            // thêm đối tượng đó vào mảng ban đầu
            return model;
        }

        public SachLy Edit()
        {
            return new SachLy();
        }

        public SachLy GetById(List<SachLy> lys, string id)
        {
            return lys.FirstOrDefault(x => x.Id == id);
        }
    }
}
