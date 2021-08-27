﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMgn
{
    public class SachToan : BaseModel
    {
        public string SachToanDif { get; set; }

        public SachToan Add(SachToan model)
        {
            // thêm đối tượng đó vào mảng ban đầu
            return model;
        }

        public SachToan Edit()
        {
            return new SachToan();
        }

        public SachToan GetByCongThucToan()
        {

        }
        public SachToan GetById(List<SachToan> toans, int id)
        {
            return toans.FirstOrDefault(x => x.Id == id);
        }
    }
}