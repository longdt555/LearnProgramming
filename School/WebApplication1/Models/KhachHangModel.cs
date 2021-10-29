using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Models
{
    [Table("KhachHang")]

    public class KhachHangModel : BaseModel
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string RandomKey { get; set; }
        public string DangHoatDong { get; set; }
        public string NhanQuangCao { get; set; }

    }
}
