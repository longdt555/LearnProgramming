using StoreManagement.Context;
using StoreManagement.Dtos.Params;
using StoreManagement.IServices;
using StoreManagement.Models;
using StoreManagement.Common.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;
using StoreManagement.Dtos.Respones;

namespace StoreManagement.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(SMDBContext _context) : base(_context) { }

        public int Add(AccountModel accountModel)
        {
            accountModel.Password = Security.Cryptography(accountModel.Password);
            DBContext().AccountModels.Add(accountModel);
            return DBContext().SaveChanges();
        }

        public void Delete(int id)
        {
            var data = (from acc in DBContext().AccountModels where acc.Id == id select acc).FirstOrDefault();
            if (data == null) return;

            data.IsDeleted = true;
            data.UpdatedDate = DateTime.Now;

            DBContext().AccountModels.Update(data);
            DBContext().SaveChanges();
        }

        public int Edit(AccountModel accountModel)
        {
            var data = DBContext().AccountModels.Where(x => x.Id == accountModel.Id).FirstOrDefault(); // mới - ngắn ngọn hơn

            var data1 = (from acc in DBContext().AccountModels where acc.Id == accountModel.Id select acc).FirstOrDefault(); // cũ - dài hơn / khi join nhiều bảng và thực hiện xử lý logic


            if (data == null) return 0;
            data.Password = accountModel.Password;
            data.Role = accountModel.Role;
            data.CreatedBy = accountModel.CreatedBy;
            data.CreatedDate = accountModel.CreatedDate;
            data.IsDeleted = accountModel.IsDeleted;
            data.UpdatedBy = accountModel.UpdatedBy;
            data.UpdatedDate = accountModel.UpdatedDate;
            data.UserName = accountModel.UserName;

            DBContext().Update(data);
            return DBContext().SaveChanges();

        }

        public List<AccountModel> GetAll()
        {
            var data = (from acc in DBContext().AccountModels
                        where acc.IsDeleted == false
                        select new AccountModel
                        {
                            Id = acc.Id,
                            Password = acc.Password,
                            Role = acc.Role,
                            CreatedBy = acc.CreatedBy,
                            CreatedDate = acc.CreatedDate,
                            IsDeleted = acc.IsDeleted,
                            UpdatedBy = acc.UpdatedBy,
                            UpdatedDate = acc.UpdatedDate,
                            UserName = acc.UserName

                        }).ToList();
            return data;
        }

        public SearchResult<AccountModel> GetAll(SearchParam<AccountParam> model)
        {
            var filter = model.Filter();

            var data = (from acc in DBContext().AccountModels
                        where acc.IsDeleted == false && (string.IsNullOrEmpty(filter.Name) || acc.UserName.ToLower().Contains(filter.Name.ToLower()))
                        select new AccountModel
                        {
                            Id = acc.Id,
                            Password = acc.Password,
                            Role = acc.Role,
                            CreatedBy = acc.CreatedBy,
                            CreatedDate = acc.CreatedDate,
                            IsDeleted = acc.IsDeleted,
                            UpdatedBy = acc.UpdatedBy,
                            UpdatedDate = acc.UpdatedDate,
                            UserName = acc.UserName
                        }).ToList();

            var dataPaging = data.Skip((model.PageIndex - 1) * model.PageSize).Take(model.PageSize);

            return new SearchResult<AccountModel>
            {
                CurrentPage = model.PageIndex,
                Data = dataPaging,
                TotalRecords = data.Count,
                PageSize = model.PageSize
            };

        }

        public AccountModel GetById(int id)
        {
            return DBContext().AccountModels.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public AccountModel Login(UserLoginParam model)
        {
            var user = DBContext().AccountModels.FirstOrDefault(x => x.UserName == model.UserName && x.Password == Security.Cryptography(model.Password));
            return user;
        }

        public int Save(AccountModel model)
        {
            #region
            var today = DateTime.Now;
            #endregion

            var user = DBContext().AccountModels.FirstOrDefault(x => x.UserName == model.UserName && x.Password == Security.Cryptography(model.Password));

            if (user.IsNull())
            {
                model.Password = Security.Cryptography(model.Password);

                model.CreatedBy = 1;
                model.CreatedDate = today;
                model.UpdatedBy = 1;
                model.UpdatedDate = today;
                model.IsDeleted = false; ;

                DBContext().AccountModels.Add(model);
            }
            else
            {
                model.UpdatedBy = 1;
                model.UpdatedDate = today;
                user.Role = model.Role;
                DBContext().AccountModels.Update(model);
            }

            return DBContext().SaveChanges();
        }
    }
}