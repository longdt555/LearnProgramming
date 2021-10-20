using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace StoreManagement.IServices
{
    public interface IDelete
    {
        List<KhachHangModel> Delete();
    }
}
