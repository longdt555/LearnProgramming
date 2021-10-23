using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Services
{
    public class HangHoaService : IHangHoa
    {
        private readonly SMDBContext _context;
        public HangHoaService(SMDBContext _context)
        {
            this._context = _context;
        }
        public List<HangHoaModel> GetAll()
        {
            var data = (from hh in _context.HangHoas
                        select new HangHoaModel
                        {
                            Id = hh.Id,
                            TenHH = hh.TenHH,
                            MaLoai = hh.MaLoai,
                            SoLuong = hh.SoLuong,
                            DonGia = hh.DonGia,
                            GiamGia = hh.GiamGia,
                            ChiTiet = hh.ChiTiet,
                            IdLoai = hh.IdLoai,
                            TenLoai = hh.TenLoai,

                        }).ToList();
            return data;
        }
    }
}
