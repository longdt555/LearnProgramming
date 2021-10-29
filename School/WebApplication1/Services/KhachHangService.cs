using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Services
{
    public class KhachHangService : BaseService, IKhachHangService
    {
        public KhachHangService(SMDBContext _context) : base(_context) { }

        public int Add(KhachHangModel khachHangModel)
        {
            DBContext().KhachHangs.Add(khachHangModel);
            return DBContext().SaveChanges();
        }

        public void Delete(int id)
        {
            var data = (from kh in DBContext().KhachHangs where kh.Id == id select kh).FirstOrDefault(); // Lấy ra đối tượng cần được xóa

            if (data == null) return;

            data.IsDeleted = true;
            data.UpdatedDate = DateTime.Now;

            DBContext().KhachHangs.Update(data);
            DBContext().SaveChanges();
        }

        public int Edit(KhachHangModel khachHangModel)
        {
            var data = DBContext().KhachHangs.Where(x => x.Id == khachHangModel.Id).FirstOrDefault();
            if (data == null) return 0;
            data.HoTen = khachHangModel.HoTen;
            data.Email = khachHangModel.Email;
            data.MatKhau = khachHangModel.MatKhau;
            data.RandomKey = khachHangModel.RandomKey;
            data.DangHoatDong = khachHangModel.DangHoatDong;
            data.NhanQuangCao = khachHangModel.NhanQuangCao;

            DBContext().KhachHangs.Update(data);
            return DBContext().SaveChanges();
        }

        public KhachHangModel GetById(int id)
        {
            return DBContext().KhachHangs.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        List<KhachHangModel> IKhachHangService.GetAll()
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
                            NhanQuangCao = kh.NhanQuangCao,

                        }).ToList();
            return data;
        }
    }
}
