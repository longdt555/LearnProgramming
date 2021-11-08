using Microsoft.AspNetCore.Mvc;
using StoreManagement.Context;
using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Services
{
    public class LoaiService : BaseService, ILoaiService
    {
        public LoaiService(SMDBContext _context) : base(_context) { }

        public int Add(LoaiModel loaiModel)
        {
            DBContext().Loais.Add(loaiModel);
            return DBContext().SaveChanges();
        }

        public void Delete(int id)
        {
            var data = (from l in DBContext().Loais where l.Id == id select l).FirstOrDefault(); // Lấy ra đối tượng cần được xóa

            if (data == null) return;

            data.IsDeleted = true;
            data.UpdatedDate = DateTime.Now;

            DBContext().Loais.Update(data);
            DBContext().SaveChanges();
        }

        public int Edit(LoaiModel loaiModel)
        {
            var data = DBContext().Loais.Where(x => x.Id == loaiModel.Id).FirstOrDefault();
            if (data == null) return 0;
            data.TenLoai = loaiModel.TenLoai;
            data.Mota = loaiModel.Mota;
            data.MaLoaiCha = loaiModel.MaLoaiCha;

            DBContext().Loais.Update(data);
            return DBContext().SaveChanges();

        }

        public List<LoaiModel> GetAll()
        {
            var data = (from loai in DBContext().Loais
                        where loai.IsDeleted == false
                        select new LoaiModel
                        {
                            Id = loai.Id,
                            TenLoai = loai.TenLoai,
                            Mota = loai.Mota,
                            MaLoaiCha = loai.MaLoaiCha,

                        }).ToList();
            return data;
        }

        public SearchResult<LoaiModel> GetAll(SearchParam<LoaiParam> model)
        {
            var filter = model.Filter();
            var data = (from l in DBContext().Loais
                        where l.IsDeleted == false && (string.IsNullOrEmpty(filter.Name)) || l.TenLoai.Contains(filter.Name)
                        select new LoaiModel()
                        {
                            Id = l.Id,
                            TenLoai = l.TenLoai,
                            Mota = l.Mota,
                            MaLoaiCha = l.MaLoaiCha,
                        } ).ToList();

            var dataPaging = data.Skip((model.PageIndex - 1) * model.PageSize).Take(model.PageSize);

            return new SearchResult<LoaiModel>
            {
                CurrentPage = model.PageIndex,
                Data = dataPaging,
                TotalRecords = data.Count,
                PageSize = model.PageSize
            };
        }

        public LoaiModel GetById(int id)
        {
            return DBContext().Loais.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        //public List<LoaiModel> Search(string search)
        //{
        //    var loai = (from l in DBContext().Loais
        //                select l);

        //    if (!String.IsNullOrEmpty(search)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
        //    {
        //        loai = loai.Where(s => s.TenLoai.Contains(search)); //lọc theo chuỗi tìm kiếm
        //    }

        //    return loai.ToList();
        //}
    }
}
