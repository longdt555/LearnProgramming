using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Models
{
    [Table("Loai")]

    public class LoaiModel:BaseModel
    {
        public string TenLoai { get; set; }
        public string Mota { get; set; }
        public int MaLoaiCha { get; set; }
    }
}
