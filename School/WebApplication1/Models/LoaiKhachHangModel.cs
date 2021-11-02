using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Models
{
    [Table("LoaiKhachHang")]
    public class LoaiKhachHangModel : BaseModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int DiscountCode { get; set; }
    }
}
