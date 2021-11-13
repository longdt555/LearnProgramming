using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.Models;
using System.Collections.Generic;

namespace StoreManagement.IServices
{
    public interface IAccountService
    {
        AccountModel Login(UserLoginParam model);
        int Save(AccountModel model);

        List<AccountModel> GetAll();
        SearchResult<AccountModel> GetAll(SearchParam<AccountParam> model);
        void Delete(int id);
        int Add(AccountModel accountModel);
        int Edit(AccountModel accountModel);
        AccountModel GetById(int id);
    }
}
