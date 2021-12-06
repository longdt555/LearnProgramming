using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Common;
using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.IServices;
using StoreManagement.Models;
using System.Diagnostics;
using System.Linq;

namespace StoreManagement.Controllers
{
    public class ChiTietDHController : BaseController
    {
        private readonly ILogger<ChiTietDHController> _logger;
        private readonly IChiTietDHService customerService;

        public ChiTietDHController(ILogger<ChiTietDHController> logger, IChiTietDHService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }

        public IActionResult Add(int id)
        {
            return PartialView("_AddPartial", customerService.GetById(id) ?? new ChiTietDHModel());
        }
        public IActionResult DoAdd(ChiTietDHModel chiTietDHModel)
        {
            if (chiTietDHModel.Id == 0)
            {
                customerService.Add(chiTietDHModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.SaveSuccessed
                });
            }
            else
            {
                customerService.Edit(chiTietDHModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.UpdateSuccessed
                });
            }
        }
        public IActionResult Edit(int id)
        {
            var chiTietDH = customerService.GetById(id);
            return View(chiTietDH);
        }
        public IActionResult DoEdit(ChiTietDHModel chiTietDHModel)
        {
            customerService.Edit(chiTietDHModel);
            return RedirectToAction("");
        }

        #region [18/11/2021] Hải
        [Route("ChiTietDH")]

        //Hiển thị danh sách người dùng mặc định
        public IActionResult List(int pageIndex, int pageSize, int maDH)
        {
            if (!isAuthenticated()) return Redirect("login");
            var searchModel = new SearchParam<ChiTietDonHangParam>(pageIndex, pageSize, new ChiTietDonHangParam(maDH));

            var customers = customerService.GetAll(searchModel);
            return View(customers);
        }

        //Thực hiện tìm kiếm theo tên
        public IActionResult Search(int pageIndex, int pageSize, int maDH)
        {
            var searchModel = new SearchParam<ChiTietDonHangParam>(pageIndex, pageSize, new ChiTietDonHangParam(maDH));

            var customers = customerService.GetAll(searchModel);
            return PartialView("_ListPartial", customers.Data.ToList());
        }

        //Xóa bản  ghi và lưu lại các thông tin đang tìm kiếm
        public IActionResult Delete(int pageIndex, int  pageSize, int maDH, int id)
        {
            //delete record
            customerService.Delete(id);

            //Sau khi xoá xong thực hiện tìm kiếm lại
            var searchModel = new SearchParam<ChiTietDonHangParam>(pageIndex, pageSize, new ChiTietDonHangParam(maDH));
            var customers = customerService.GetAll(searchModel);
            return PartialView("_ListPartial", customers.Data.ToList());
        }
        #endregion [18/11/2021] Hải
    }
}
