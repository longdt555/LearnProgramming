using StoreManagement.Dtos;
using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.Models;
using System.Collections.Generic;

namespace StoreManagement.IServices
{
    public interface IChiTietDHService
    {
        //List<ChiTietDHModel> GetChiTietDHDto();

        List<ChiTietDHModel> GetAll();
        SearchResult<ChiTietDHModel> GetAll(SearchParam<ChiTietDonHangParam> model);

        void Delete(int id);
        int Add(ChiTietDHModel chiTietDHModel);
        ChiTietDHModel GetById(int id);
        int Edit(ChiTietDHModel chiTietDHModel);
    }
}
