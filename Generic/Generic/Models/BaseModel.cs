using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int NumberOfPages { get; set; }
        public string Actor { get; set; }
        public DateTime? PublishedDate { get; set; }
        public double Price { get; set; }


    }
}
