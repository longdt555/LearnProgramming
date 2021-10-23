using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Services
{
    public class LoaiService : ILoai
    {
        private readonly SMDBContext _context;
        public LoaiService(SMDBContext _context)
        {
            this._context = _context;
        }

        public List<LoaiModel> GetAll()
        {
            var data = (from loai in _context.Loais
                        select new LoaiModel
                        {
                            Id = loai.Id,
                            TenLoai = loai.TenLoai,
                            Mota = loai.Mota,
                            MaLoaiCha = loai.MaLoaiCha,

                        }).ToList();
            return data;
        }
    }
}
