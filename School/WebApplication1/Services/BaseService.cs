using StoreManagement.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Services
{
    public class BaseService
    {
        private readonly object Locker = new object();
        private readonly SMDBContext _context;
        public BaseService(SMDBContext _context)
        {
            this._context = _context;
        }

        public SMDBContext DBContext()
        {
            lock (Locker)
                return _context;
        }
    }
}
