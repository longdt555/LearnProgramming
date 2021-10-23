using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Models
{
    [Table("DonHang")]

    public class DonHangModel : BaseModel
    {
        public int IdKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime? NgayLap { get; set; }
        public float PhiVanChuyen { get; set; }
        public float ThanhTien { get; set; }
        public float TongTien { get; set; }
        public string TrangThaiDonHang { get; set; }
        public string TrangThaiThanhToan { get; set; }
        public KhachHangModel khachhang { get; set; }

    }
}
