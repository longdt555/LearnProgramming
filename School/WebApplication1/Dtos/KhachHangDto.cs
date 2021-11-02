using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Dtos
{
    public class KhachHangDto : BaseDto
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string RandomKey { get; set; }
        public string DangHoatDong { get; set; }
        public string NhanQuangCao { get; set; }
        public int IdLoaiKhachHang { get; set; }
        public string LoaiKhachHang { get; set; }
    }
}
