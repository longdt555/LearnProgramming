using Microsoft.EntityFrameworkCore.Internal;
using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Dtos;

namespace StoreManagement.Services
{
    public class DonHangService : IDonHangService
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

        // inner join
        // left join
        public List<DonHangDto> GetAll()
        {
            //var query = from person in people
            //    join pet in pets on person equals pet.Owner into gj
            //    from subpet in gj.DefaultIfEmpty()
            //    select new { person.FirstName, PetName = subpet?.Name ?? String.Empty };

            // JOIN: from [table1] join [table2] on [condition] where [condition] select [model]

            var donHangDtos = (from dh in _context.DonHangs
                               join kh in _context.KhachHangs
                                   on dh.IdKhachHang equals kh.Id into dhkh
                               from khlj in dhkh.DefaultIfEmpty()


                               //where !khlj.IsDeleted && !dh.IsDeleted
                               select new DonHangDto
                               {
                                   Id = dh.Id,
                                   IdKhachHang = dh.IdKhachHang,
                                   Email = khlj.Email,
                                   TenKhachHang = khlj.HoTen,
                                   NgayLap = dh.NgayLap,
                                   PhiVanChuyen = dh.PhiVanChuyen,
                                   ThanhTien = dh.ThanhTien,
                                   TongTien = dh.TongTien,
                                   TrangThaiDonHang = dh.TrangThaiDonHang,
                                   TrangThaiThanhToan = dh.TrangThaiThanhToan
                               }).ToList();
            return donHangDtos;
        }

    }
}
