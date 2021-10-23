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
        List<DonHangDto> GetAll();

        //List<DonHangModel> Get();

    }
}
