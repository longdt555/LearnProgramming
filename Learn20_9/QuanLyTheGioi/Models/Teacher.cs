using System;
using System.Collections.Generic;
using System.Text;
using QuanLyTheGioi.AbtractRepo;
using QuanLyTheGioi.Interface;

namespace QuanLyTheGioi.Models
{
    class Teacher : Person, IWoman, IMan
    {
        public int SoNamGiangDay { get; set; }
    }
}
