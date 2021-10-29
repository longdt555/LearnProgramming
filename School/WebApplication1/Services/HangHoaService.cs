using StoreManagement.Context;
using StoreManagement.Dtos;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Services
{
    public class HangHoaService : BaseService, IHangHoaService
    {
        public HangHoaService(SMDBContext _context) : base(_context) { }

        public int Add(HangHoaModel hangHoaModel)
        {
            DBContext().HangHoas.Add(hangHoaModel);
            return DBContext().SaveChanges();
        }
        public void Delete(int id)
        {
            var data = (from hh in DBContext().HangHoas where hh.Id == id select hh).FirstOrDefault(); // Lấy ra đối tượng cần được xóa

            if (data == null) return;

            data.IsDeleted = true;
            data.UpdatedDate = DateTime.Now;

            DBContext().HangHoas.Update(data);
            DBContext().SaveChanges();
        }

        public int Edit(HangHoaModel hangHoaModel)
        {
            var data = DBContext().HangHoas.Where(x => x.Id == hangHoaModel.Id).FirstOrDefault();
            if (data == null) return 0;
            data.TenHH = hangHoaModel.TenHH;
            data.SoLuong = hangHoaModel.SoLuong;
            data.DonGia = hangHoaModel.DonGia;
            data.GiamGia = hangHoaModel.GiamGia;
            data.ChiTiet = hangHoaModel.ChiTiet;

            DBContext().HangHoas.Update(data);
            return DBContext().SaveChanges();
        }

        public List<HangHoaModel> GetAll()
        {
            var data = (from hh in DBContext().HangHoas
                        where hh.IsDeleted == false
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

        public HangHoaModel GetById(int id)
        {
            return DBContext().HangHoas.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public List<HangHoaDto> GetHangHoaDto()
        {
            var hangHoaDtos = (from hh in DBContext().HangHoas
                               join loai in DBContext().Loais
                                  on hh.IdLoai equals loai.Id into hhl
                               from hhloai in hhl.DefaultIfEmpty()
                               where hhloai.IsDeleted == false

                               select new HangHoaDto
                               {
                                   Id = hh.Id,
                                   TenHH = hh.TenHH,
                                   TenLoai = hhloai.TenLoai,
                                   SoLuong = hh.SoLuong,
                                   MoTa = hhloai.Mota,
                                   DonGia = hh.DonGia,
                                   ChiTiet = hh.ChiTiet
                               }).ToList();

            return hangHoaDtos;


        }
    }
}
