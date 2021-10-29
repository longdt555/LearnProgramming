using StoreManagement.Models;
using System.Collections.Generic;

namespace StoreManagement.IServices
{
    public interface ICustomerService
    {
         List<KhachHangModel> GetAll();

    }
}
