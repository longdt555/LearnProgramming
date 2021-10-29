using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Dtos
{
    public class ChiTietDHDto : BaseDto
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public int MaDH { get; set; }
        public string TenHH { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
    }
}
