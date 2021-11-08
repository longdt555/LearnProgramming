using StoreManagement.Context;
using StoreManagement.Dtos;
using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.Services
{
    public class ChiTietDHService : BaseService, IChiTietDHService
    {
        public ChiTietDHService(SMDBContext _context) : base(_context) { }

        public int Add(ChiTietDHModel chiTietDHModel)
        {
            DBContext().ChiTietDHs.Add(chiTietDHModel);
            return DBContext().SaveChanges();
        }

        public void Delete(int id)
        {
            var data = (from ctdh in DBContext().ChiTietDHs where ctdh.Id == id select ctdh).FirstOrDefault(); // Lấy ra đối tượng cần được xóa

            if (data == null) return;

            data.IsDeleted = true;
            data.UpdatedDate = DateTime.Now;

            DBContext().ChiTietDHs.Update(data);
            DBContext().SaveChanges();
        }

        public int Edit(ChiTietDHModel chiTietDHModel)
        {
            var data = DBContext().ChiTietDHs.Where(x => x.Id == chiTietDHModel.Id).FirstOrDefault();
            if (data == null) return 0;
            data.CreatedBy = chiTietDHModel.CreatedBy;
            data.CreatedDate = chiTietDHModel.CreatedDate;
            data.UpdatedDate = chiTietDHModel.UpdatedDate;
            data.UpdatedBy = chiTietDHModel.UpdatedBy;
            data.IsDeleted = chiTietDHModel.IsDeleted;
            data.MaDH = chiTietDHModel.MaDH;
            data.DonGia = chiTietDHModel.DonGia;
            data.SoLuong = chiTietDHModel.SoLuong;

            DBContext().Update(data);
            return DBContext().SaveChanges();
            
        }

        public SearchResult<ChiTietDHModel> GetAll(SearchParam<ChiTietDonHangParam> model)
        {
            var filter = model.Filter();


            var data = (from ctdh in DBContext().ChiTietDHs
                        where ctdh.IsDeleted == false && (string.IsNullOrEmpty(filter.MaDH.ToString())) || ctdh.MaDH.ToString().Contains(filter.MaDH.ToString())
                        select new ChiTietDHModel
                        {
                            Id = ctdh.Id,
                            CreatedBy = ctdh.CreatedBy,
                            CreatedDate = ctdh.CreatedDate,
                            UpdatedDate = ctdh.UpdatedDate,
                            UpdatedBy = ctdh.UpdatedBy,
                            IsDeleted = ctdh.IsDeleted,
                            MaDH = ctdh.MaDH,
                            MaHH = ctdh.MaHH,
                            DonGia = ctdh.DonGia,
                            SoLuong = ctdh.SoLuong

                        }).ToList();
            var dataPaging = data.Skip((model.PageIndex - 1) * model.PageSize).Take(model.PageSize);

            return new SearchResult<ChiTietDHModel>
            {
                CurrentPage = model.PageIndex,
                Data = dataPaging,
                TotalRecords = data.Count,
                PageSize = model.PageSize
            };
        }

        public ChiTietDHModel GetById(int id)
        {
            return DBContext().ChiTietDHs.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }



        //public List<ChiTietDHModel> Delete()
        //{
        //    var deleteOrderDetails =
        //              from ctdh in _context.ChiTietDHs
        //              where ctdh.Id == ctdh.MaDH
        //              select ctdh;

        //    foreach (var ctdh in deleteOrderDetails)
        //    {
        //        _context.ChiTietDHs.DeleteOnSubmit(ctdh);
        //    }

        //    try
        //    {
        //        db.SubmitChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        // Provide for exceptions.
        //    }
        //}

        //public List<ChiTietDHDto> GetChiTietDHDto()
        //{
        //    var chiTietDonHangs = (from kh in DBContext().KhachHangs
        //                           join dh in DBContext().DonHangs
        //                               on kh.Id equals dh.Id
        //                           join hh in DBContext().HangHoas on dh.Id equals hh.Id


        //                           //    into dhkh
        //                           //from khlj in dhkh.DefaultIfEmpty()


        //                           where !kh.IsDeleted && !dh.IsDeleted
        //                           select new ChiTietDHDto
        //                           {
        //                               Id = dh.Id,
        //                               HoTen = kh.HoTen,
        //                               Email = kh.Email,
        //                               MaDH = dh.Id,
        //                               TenHH = hh.TenHH,
        //                               SoLuong = hh.SoLuong,
        //                               DonGia = hh.DonGia
        //                           }).ToList();
        //    return chiTietDonHangs;
        //}

        //public List<ChiTietDHModel> Insert()
        //{
        //    var ChiTietDH = new List
        //}

        List<ChiTietDHModel> IChiTietDHService.GetAll()
        {
            var data = (from ctdh in DBContext().ChiTietDHs
                        where ctdh.IsDeleted == false
                        select new ChiTietDHModel
                        {
                            Id = ctdh.Id,
                            CreatedBy = ctdh.CreatedBy,
                            CreatedDate = ctdh.CreatedDate,
                            UpdatedDate = ctdh.UpdatedDate,
                            UpdatedBy = ctdh.UpdatedBy,
                            IsDeleted = ctdh.IsDeleted,
                            MaDH = ctdh.MaDH,
                            MaHH = ctdh.MaHH,
                            DonGia = ctdh.DonGia,
                            SoLuong = ctdh.SoLuong

                        }).ToList();
            return data;
        }
    }
}
