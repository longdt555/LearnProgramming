using StoreManagement.Dtos;
using StoreManagement.Models;
using System.Collections.Generic;

namespace StoreManagement.IServices
{
    public interface IChiTietDHService
    {
        List<ChiTietDHDto> GetChiTietDHDto();

        List<ChiTietDHModel> GetAll();

        void Delete(int id);
        int Add(ChiTietDHModel chiTietDHModel);
        ChiTietDHModel GetById(int id);
        int Edit(ChiTietDHModel chiTietDHModel);
    }
}
