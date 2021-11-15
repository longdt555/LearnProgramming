using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Models
{
    [Table("Quyen")]
    public class RoleModel : BaseModel
    {
        public string Name { get; set; }
    }
}
