using System.ComponentModel.DataAnnotations.Schema;

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
