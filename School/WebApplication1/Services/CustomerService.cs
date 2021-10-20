using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly SMDBContext _context;
        public CustomerService(SMDBContext context)
        {
            this._context = context;
        }

        public List<KhachHangModel> GetAll()
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
                    NhanQuangCao = kh.NhanQuangCao

                }).ToList();
            return data;
        }

        #region [Private functions helper]
        

        #endregion [Private functions helper]
    }
}
