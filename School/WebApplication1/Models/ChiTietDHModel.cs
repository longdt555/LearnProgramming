using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Models
{
    [Table("ChiTietDH")]

    public class ChiTietDHModel : BaseModel
    {
        public int MaDH { get; set; }
        public int MaHH { get; set; }
        public float DonGia { get; set; }
        public int SoLuong { get; set; }
    }
}
