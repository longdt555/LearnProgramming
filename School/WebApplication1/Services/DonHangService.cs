using Microsoft.EntityFrameworkCore.Internal;
using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Dtos;
using StoreManagement.Dtos.Respones;
using StoreManagement.Dtos.Params;
using StoreManagement.Data;

namespace StoreManagement.Services
{
    public class DonHangService : BaseService, IDonHangService
    {
        public DonHangService(SMDBContext _context) : base(_context) { }

        public int Add(DonHangModel donHangModel)
        {
            DBContext().DonHangs.Add(donHangModel);
            return DBContext().SaveChanges();
        }

        public void Delete(int id)
        {
            var data = (from dh in DBContext().DonHangs where dh.Id == id select dh).FirstOrDefault(); // Lấy ra đối tượng cần được xóa

            if (data == null) return;

            data.IsDeleted = true;
            data.UpdatedDate = DateTime.Now;

            DBContext().DonHangs.Update(data);
            DBContext().SaveChanges();
        }

        public int Edit(DonHangModel donHangModel)
        {
            var data = DBContext().DonHangs.Where(x => x.Id == donHangModel.Id).FirstOrDefault();
            if (data == null) return 0;
            data.PhiVanChuyen = donHangModel.PhiVanChuyen;
            data.ThanhTien = donHangModel.ThanhTien;
            data.TongTien = donHangModel.TongTien;
            data.TrangThaiDonHang = donHangModel.TrangThaiDonHang;
            data.TrangThaiThanhToan = donHangModel.TrangThaiThanhToan;
            DBContext().DonHangs.Update(data);
            return DBContext().SaveChanges();
        }

        public SearchResult<DonHangModel> GetAll(SearchParam<DonHangParam> model)
        {
            #region [Params]

            var filter = model.Filter();
            //var currentUser = LoggedOnUser.Get();

            #endregion [Params]

            var data = (from dh in DBContext().DonHangs
                        where dh.IsDeleted == false && (string.IsNullOrEmpty(filter.TrangThaiDonHang)) || dh.TrangThaiDonHang.Contains(filter.TrangThaiDonHang)
                        select new DonHangModel
                        {
                            Id = dh.Id,
                            IdKhachHang = dh.IdKhachHang,
                            NgayLap = dh.NgayLap,
                            PhiVanChuyen = dh.PhiVanChuyen,
                            ThanhTien = dh.ThanhTien,
                            TongTien = dh.TongTien,
                            TrangThaiDonHang = dh.TrangThaiDonHang,
                            TrangThaiThanhToan = dh.TrangThaiThanhToan,
                            MaKH = dh.MaKH
                        }).ToList();

            //if ((int)currentUser.Role != 1)
            //{
            //    data = data.Where(x => x.MaKH == currentUser.Id).ToList();
            //}

            var dataPaging = data.Skip((model.PageIndex - 1) * model.PageSize).Take(model.PageSize);

            return new SearchResult<DonHangModel>
            {
                CurrentPage = model.PageIndex,
                Data = dataPaging,
                TotalRecords = data.Count,
                PageSize = model.PageSize
            };
        }

        public DonHangModel GetById(int id)
        {
            return DBContext().DonHangs.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        List<DonHangModel> IDonHangService.GetAll()
        {
            var donHang = (from dh in DBContext().DonHangs
                           where dh.IsDeleted == false
                           select new DonHangModel
                           {
                               Id = dh.Id,
                               IdKhachHang = dh.IdKhachHang,
                               NgayLap = dh.NgayLap,
                               PhiVanChuyen = dh.PhiVanChuyen,
                               ThanhTien = dh.ThanhTien,
                               TongTien = dh.TongTien,
                               TrangThaiDonHang = dh.TrangThaiDonHang,
                               TrangThaiThanhToan = dh.TrangThaiThanhToan,

                           }).ToList();
            return donHang;
        }
    }

}
