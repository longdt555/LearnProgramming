using System;
using System.Collections.Generic;
using BookMgn.Repo;

namespace BookMgn
{
    class Program
    {
        static void Main(string[] args)
        {
            // normal
            var dsSachLy = new List<SachLy>();
            var dsSachHoa = new List<SachHoa>();

            var sachLy = new SachLy();
            sachLy.Add(new SachLy());

            var sachHoa = new SachHoa();
            sachHoa.Add(new SachHoa());

            // generic
            var dsGSachLy = new CommonRepo<SachLy>();
            var dsGSachHoa = new CommonRepo<SachHoa>();
            dsGSachLy.Add(new SachLy());


            Console.WriteLine("Quản lý đầu sách!");
        }
    }
}
