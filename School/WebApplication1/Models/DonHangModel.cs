﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Models
{
    [Table("DonHang")]

    public class DonHangModel : BaseModel
    {
        public int MaKH { get; set; }
        public DateTime NgayLap { get; set; }
        public float PhiVanChuyen { get; set; }
        public float ThanhTien { get; set; }
        public float TongTien { get; set; }
        public string TrangThaiDonHang { get; set; }
        public string TrangThaiThanhToan { get; set; }

    }
}
