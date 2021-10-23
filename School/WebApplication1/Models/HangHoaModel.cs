using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Models
{
    [Table("HangHoa")]

    public class HangHoaModel : BaseModel
    {
        public string TenHH { get; set; }
        public string TenLoai { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float GiamGia { get; set; }
        public string ChiTiet { get; set; }
        public int IdLoai { get; set; }
        public string MaLoai { get; set; }
    }
}
