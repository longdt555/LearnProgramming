using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Dtos.Params
{
    public class DonHangParam
    {
        #region [Construtor]

        public DonHangParam(string trangThaiDonHang)
        {
            TrangThaiDonHang = trangThaiDonHang;
        }

        #endregion [Construtor]
        public string TrangThaiDonHang { get; set; }
    }
}
