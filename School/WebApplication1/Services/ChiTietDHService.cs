using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.Services
{
    public class ChiTietDHService : IChiTietDH 
    {
        private readonly SMDBContext _context;
        public ChiTietDHService(SMDBContext _context)
        {
            this._context = _context;
        }

        List<ChiTietDHModel> IChiTietDH.GetAll()
        {
            var data = (from ctdh in _context.ChiTietDHs
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
