using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.IServices
{
    interface IAccountService
    {
        List<AccountModel> Login(AccountModel acc);
    }
}
