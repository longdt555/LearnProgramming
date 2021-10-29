using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Dtos;

namespace StoreManagement.IServices
{
    public interface IDonHangService
    {
        List<DonHangDto> GetDonHangDto();

        List<DonHangDto> GetAll();  //sửa sang Don Hang Model ///

        void Delete(int id);
        int Add(DonHangModel donHangModel);
        DonHangModel GetById(int id);
        int Edit(DonHangModel donHangModel);
    }
}
