using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Models
{
    [Table("HangHoa")]

    public class HangHoaModel
    {
        [Key]
        public int Id { get; set; }
        public string TenHH { get; set; }
        public string MaLoai { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float GiamGia { get; set; }
        public string ChiTiet { get; set; }

    }
}
