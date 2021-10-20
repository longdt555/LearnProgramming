using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Models
{
    [Table("Loai")]

    public class LoaiModel
    {
        [Key]
        public int Id { get; set; }
        public string TenLoai { get; set; }
        public string Mota { get; set; }
        public int MaLoaiCha { get; set; }

        //public LoaiModel(string tenLoai, string moTa, int maLoaiCha)
        //{
        //    TenLoai = tenLoai; Mota = moTa; MaLoaiCha = maLoaiCha;
        //}

        //override public string ToString()
        //  => $"{Id,3} {TenLoai,12} {Mota,5} {MaLoaiCha,2}";


    }
}
