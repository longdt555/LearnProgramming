using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(SMDBContext _context) : base(_context) { }
        //public List<AccountModel> Login()
        //{
        //    var data = DBContext().AccountModels.Where(x => x.)
        //}

        public List<AccountModel> Login(AccountModel acc)
        {
            //var data = DBContext().AccountModels.Where(x => x.Name == acc.Name && x.Password == acc.Password).ToList();

            return null;
        }
    }
}
