using Microsoft.AspNetCore.Mvc;
using StoreManagement.Models;
using StoreManagement.IServices;
using StoreManagement.Dtos.Params;
using StoreManagement.Common.Helpers;
using StoreManagement.Data;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace StoreManagement.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> _logger;

        private readonly IAccountService customerService;
        public AccountController(ILogger<AccountController> logger, IAccountService _service)
        {
            _logger = logger;
            this.customerService = _service;
        }


        public IActionResult DoLogin(string userName, string password, bool remeberMe)
        {
            #region

            #endregion
            var acc = new UserLoginParam(userName, password, remeberMe);
            var logged = customerService.Login(acc);
            if (logged.IsNull())
            {
                return RedirectToAction("Index", "Error");
            }
            LoggedOnUser.Set(logged);

            return RedirectToAction("Index", "Home");

        }

        [Route("login")]
        [Route("")]

        public IActionResult Login()
        {
            if (isAuthenticated()) return Redirect("Home");
            return View();
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            LoggedOnUser.Set(null);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Save()
        {
            //var executed = customerService.Save(new AccountModel { UserName = "longdt", Password = "123456", Role = Common.Enum.RoleEnum.User });
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index(int pg = 1)
        {
            var customers = customerService.GetAll();
            const int pageSize = 5;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = customers.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = customers.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View();

        }


        public IActionResult Add(int id)
        {
            return PartialView("_AddPartial", customerService.GetById(id) ?? new AccountModel());
        }
        public IActionResult DoAdd(AccountModel accountModel)
        {
            #region [Validate]

            //if (string.IsNullOrEmpty(accountModel.UserName))
            //{
            //    return RedirectToAction("index", "error", new { message = "Không được bỏ trống tài khoản." });
            //};

            //if (string.IsNullOrEmpty(accountModel.Password))
            //{
            //    return RedirectToAction("index", "error", new { message = "Không được bỏ trống mật khẩu." });
            //};

            #endregion [Validate]

            customerService.Add(accountModel);
            return Redirect("List");
        }
        public IActionResult Edit(int id)
        {
            var acc = customerService.GetById(id);
            return View(acc);
        }

        public IActionResult DoEdit(AccountModel accountModel)
        {
            customerService.Edit(accountModel);
            return RedirectToAction("");
        }

        #region [16/11/2021]

        /// <summary>
        /// Hiển thị danh sách người dùng mặc định
        /// </summary>
        /// <returns></returns>
        [Route("Account")]
        public IActionResult List()
        {
            //if (!isAuthenticated()) return Redirect("login");
            var searchModel = new SearchParam<AccountParam>(1, 20, new AccountParam());

            var customers = customerService.GetAll(searchModel);
            return View(customers);
        }

        /// <summary>
        /// Thực hiện tìm kiếm theo tên
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IActionResult Search(int pageIndex, int pageSize, string name)
        {
            var searchModel = new SearchParam<AccountParam>(pageIndex, pageSize, new AccountParam(name));

            var customers = customerService.GetAll(searchModel);
            return PartialView("~/Views/Account/_ListPartial.cshtml", customers.Data.ToList());
        }

        /// <summary>
        /// Xoá bản ghi và lưu lại các thông tin đang tìm kiếm
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int pageIndex, int pageSize, string name, int id)
        {
            // delete record
            customerService.Delete(id);

            // Sau khi xóa xong thực hiện tìm kiếm lại
            var searchModel = new SearchParam<AccountParam>(pageIndex, pageSize, new AccountParam(name));
            var customers = customerService.GetAll(searchModel);
            return PartialView("~/Views/Account/_ListPartial.cshtml", customers.Data.ToList());
        }

        #endregion [16/11/2021]
    }
}
