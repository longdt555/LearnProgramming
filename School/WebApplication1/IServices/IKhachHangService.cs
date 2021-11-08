using StoreManagement.Dtos.Params;
using StoreManagement.Models;
using System.Collections.Generic;
using StoreManagement.Dtos;
using StoreManagement.Dtos.Respones;

namespace StoreManagement.IServices
{
    public interface IKhachHangService
    {
        List<KhachHangModel> GetAll();
        SearchResult<KhachHangModel> GetAll(SearchParam<KhachHangParam> model);
        void Delete(int id);
        int Add(KhachHangModel khachHangModel);
        KhachHangModel GetById(int id);
        int Edit(KhachHangModel khachHangModel);

    }
}
