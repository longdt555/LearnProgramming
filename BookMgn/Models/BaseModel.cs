using System;

namespace BookMgn.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Actor { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
