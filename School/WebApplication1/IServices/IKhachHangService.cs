using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.IServices
{
    public interface IKhachHangService
    {
        List<KhachHangModel> GetAll();
        void Delete(int id);

        int Add(KhachHangModel khachHangModel);
        KhachHangModel GetById(int id);
        int Edit(KhachHangModel khachHangModel);

    }
}
