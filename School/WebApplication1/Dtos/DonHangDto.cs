using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Dtos
{
    public class DonHangDto : BaseDto
    {
        public List<HangHoaDto> HangHoaDtos { get; set; }
        public int IdKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string Email { get; set; }
        public DateTime? NgayLap { get; set; }
        public float PhiVanChuyen { get; set; }
        public float ThanhTien { get; set; }
        public float TongTien { get; set; }
        public string TrangThaiDonHang { get; set; }
        public string TrangThaiThanhToan { get; set; }
    }
}
