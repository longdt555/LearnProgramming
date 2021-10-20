using StoreManagement.Context;
using StoreManagement.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace StoreManagement.Services
{
    public class DeleteService : IDelete
    {
        private readonly SMDBContext _context;
        public DeleteService(SMDBContext _context)
        {
            this._context = _context;
        }
        public List<KhachHangModel> Delete()
        {
            return _context.KhachHangs.ToList();
        }
    }
}
