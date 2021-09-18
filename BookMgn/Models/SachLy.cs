using System.Collections.Generic;

namespace BookMgn.Models
{
    public class SachLy // class
    {
        //public SachLy(int pageNumber)
        //{
        //    _data = new List<SachHoa>
        //    {
        //        new SachHoa()
        //        {
        //            Id = 1,
        //            PageNumber = 20,
        //            NameCombine = "SachLy_Lop_1"
        //        },
        //        new SachHoa()
        //        {
        //            Id = 2,
        //            PageNumber = 20,
        //            NameCombine = "SachLy_Lop_2"
        //        }
        //    };
        //    PageNumber = pageNumber;
        //}

        public List<SachHoa> _data { get; set; }
        public string suffixName = "SachLy_";

        private string NameCombine { get; set; }
        public int PageNumber { get; set; }
        public int Id { get; set; }

        public void CombineValue(string name)
        {

            NameCombine = suffixName + name;
        }

        public string GetValue()
        {
            return NameCombine;
        }

        public List<SachHoa> GetData()
        {
            return _data;
        }

        //public void PrintData()
        //{
        //    foreach (var item in GetData())
        //    {
        //        Console.Write($"Id: {item.Id}, Name: {item.NameCombine}, PageNumber: {item.PageNumber}");
        //    }
        //}
    }
}
