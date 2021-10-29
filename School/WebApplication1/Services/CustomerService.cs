using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(SMDBContext _context) : base(_context) { }

        public List<KhachHangModel> GetAll()
        {
            var data = (from kh in DBContext().KhachHangs
                        where kh.IsDeleted == false
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
