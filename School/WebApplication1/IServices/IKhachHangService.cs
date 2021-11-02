using StoreManagement.Dtos.Params;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Dtos;

namespace StoreManagement.IServices
{
    public interface IKhachHangService
    {
        List<KhachHangDto> GetAll(/*SearchParam<KhachHangModel> model)*/);
        void Delete(int id);

        int Add(KhachHangModel khachHangModel);
        KhachHangModel GetById(int id);
        int Edit(KhachHangModel khachHangModel);

    }
}
