using Microsoft.AspNetCore.Mvc;
using StoreManagement.Context;
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

        public LoaiModel GetById(int id)
        {
            return DBContext().Loais.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }
    }
}
