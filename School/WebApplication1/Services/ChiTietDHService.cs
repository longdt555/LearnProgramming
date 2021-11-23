using StoreManagement.Context;
using StoreManagement.Dtos;
using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using StoreManagement.Common.Helpers;

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
            #region [Params]

            var filter = model.Filter();

            #endregion [Params]

            #region [Query]

            var query = (from ctdh in DBContext().ChiTietDHs
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

            #endregion [Query]

            #region [Filter]
            var maDHv2 = ConvertHelper.ConvertToInt(filter.MaDH);

            if (maDHv2 > 0)
            {
                query = query.Where(x => x.MaDH == maDHv2).ToList();
            }

            #endregion [Filter]

            #region [Paging]

            var dataPaging = query.Skip((model.PageIndex - 1) * model.PageSize).Take(model.PageSize);

            #endregion [Paging]


            return new SearchResult<ChiTietDHModel>
            {
                CurrentPage = model.PageIndex,
                Data = dataPaging,
                TotalRecords = query.Count,
                PageSize = model.PageSize
            };
        }

        public ChiTietDHModel GetById(int id)
        {
            return DBContext().ChiTietDHs.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }



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
