using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Models
{
    [Table("KhachHang")]

    public class KhachHangModel
    {
        [Key]
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string RandomKey { get; set; }
        public string DangHoatDong { get; set; }
        public string NhanQuangCao { get; set; }

    }
}
