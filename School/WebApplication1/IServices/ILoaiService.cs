using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.IServices
{
    public interface ILoaiService
    {
        List<LoaiModel> GetAll();
        SearchResult<LoaiModel> GetAll(SearchParam<LoaiParam> model);

        //List<LoaiModel> Search(string search);
        void Delete(int id);
        int Add(LoaiModel loaiModel);
        LoaiModel GetById(int id);
        int Edit(LoaiModel loaiModel);
    }
}
