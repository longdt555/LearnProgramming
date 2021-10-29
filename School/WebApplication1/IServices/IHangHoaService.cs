using StoreManagement.Dtos;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.IServices
{
    public interface IHangHoaService
    {
        List<HangHoaDto> GetHangHoaDto();

        List<HangHoaModel> GetAll();

        void Delete(int id);
        int Add(HangHoaModel hangHoaModel);
        HangHoaModel GetById(int id);

        int Edit(HangHoaModel hangHoaModel);

    }
}
