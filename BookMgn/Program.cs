using System;
using System.Collections.Generic;
using System.Linq;
using BookMgn.Models;
using BookMgn.Repo;

namespace BookMgn
{
    class Program
    {
        static void Main(string[] args)
        {
            var SachLyLop1 = new SachLy(); // đối tượng
            SachLyLop1.suffixName = "Long_HackRoiCon_";
            
            SachLyLop1._data.Add(new SachHoa());

            SachLyLop1.CombineValue("Lop 1");

            Console.WriteLine(SachLyLop1.GetValue());

            //SachLyLop1.PrintData();


        }
    }
}
