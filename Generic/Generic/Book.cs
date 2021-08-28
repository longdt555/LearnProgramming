using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class Book
    {// id, tên, thể loại, số trang, tác giả, năm phát hành, giá bán và không được trùng lặp

        public int bookId { get; set; }
        public string bookName { get; set; }
        public string bookCategory { get; set; }
        public int bookNumberofBook { get; set; }
        public string bookAuthor { get; set; }
        public int bookDate { get; set; }
        public double bookPrice { get; set; }


    }
}
