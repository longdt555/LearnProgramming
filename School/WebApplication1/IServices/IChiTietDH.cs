using StoreManagement.Models;
using System.Collections.Generic;

namespace StoreManagement.IServices
{
    public interface IChiTietDH
    {
        List<ChiTietDHModel> GetAll();
    }
}
