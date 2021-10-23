using Microsoft.EntityFrameworkCore.Internal;
using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Services
{
    public class DonHangService : IDonHang 
    {
        private readonly SMDBContext _context;
        public DonHangService(SMDBContext _context)
        {
            this._context = _context;
        }

        //     public List<DonHangModel> Get()
        //     {
        //         var query =
        //(from dh in _context.DonHangs
        // join kh in _context.KhachHangs on dh.TenKhachHang equals kh.Email
        // where kh.Id == dh.Id
        // select new { kh = kh, dh = dh }).ToList();

        //         return query;
        //     }
                                           
        public List<DonHangModel> GetAll()
        {
            var data1 = (from dh in _context.DonHangs
                        select new DonHangModel
                        {
                            Id = dh.Id,
                            IdKhachHang = dh.IdKhachHang,
                            TenKhachHang = dh.TenKhachHang,
                            NgayLap = dh.NgayLap,
                            PhiVanChuyen = dh.PhiVanChuyen,
                            ThanhTien = dh.ThanhTien,
                            TongTien = dh.TongTien,
                            TrangThaiDonHang = dh.TrangThaiDonHang,
                            TrangThaiThanhToan = dh.TrangThaiThanhToan,

                        }).ToList();
            return data1;
        }

    }
}
