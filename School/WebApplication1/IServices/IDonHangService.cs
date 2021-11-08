using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Dtos;
using StoreManagement.Dtos.Respones;
using StoreManagement.Dtos.Params;

namespace StoreManagement.IServices
{
    public interface IDonHangService
    {
        List<DonHangModel> GetAll();  //sửa sang Don Hang Model ///
        SearchResult<DonHangModel> GetAll(SearchParam<DonHangParam> model);
        void Delete(int id);
        int Add(DonHangModel donHangModel);
        DonHangModel GetById(int id);
        int Edit(DonHangModel donHangModel);
    }
}
