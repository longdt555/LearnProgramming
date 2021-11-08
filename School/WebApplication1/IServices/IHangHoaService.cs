using StoreManagement.Dtos;
using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.IServices
{
    public interface IHangHoaService
    {
        List<HangHoaModel> GetHangHoaDto();

        List<HangHoaModel> GetAll();
        SearchResult<HangHoaModel> GetAll(SearchParam<HangHoaParam> model);


        void Delete(int id);
        int Add(HangHoaModel hangHoaModel);
        HangHoaModel GetById(int id);

        int Edit(HangHoaModel hangHoaModel);

    }
}
