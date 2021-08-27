using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMgn
{
    public class SachHoa : BaseModel
    {
        public string SachHoaDif { get; set; }

        public SachHoa Add(SachHoa model)
        {
            // thêm đối tượng đó vào mảng ban đầu
            return model;
        }

        public SachHoa Edit()
        {
            return new SachHoa();
        }

        public SachHoa GetById(List<SachHoa> hoas, int id)
        {
            return hoas.FirstOrDefault(x => x.Id == id);
        }
    }
}
