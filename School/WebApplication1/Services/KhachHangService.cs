using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Services
{
    public class KhachHangService : IKhachHang
    {
        private readonly SMDBContext _context;
        public KhachHangService(SMDBContext _context)
        {
            this._context = _context;
        }

        List<KhachHangModel> IKhachHang.GetAll()
        {
            var data = (from kh in _context.KhachHangs
                        select new KhachHangModel
                        {
                            Id = kh.Id,
                            HoTen = kh.HoTen,
                            Email = kh.Email,
                            MatKhau = kh.MatKhau,
                            RandomKey = kh.RandomKey,
                            DangHoatDong = kh.DangHoatDong,
                            NhanQuangCao = kh.NhanQuangCao,

                        }).ToList();
            return data;
        }
    }
}
