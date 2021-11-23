using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Dtos.Params;
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
        //[Route("ChiTietDonHang")]

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
            return View(data);
        }
      
        //[Route("ChiTietDonHang")]

        //public IActionResult Details()
        //{
        //    var customers = customerService.GetAll();
        //    return View(customers);
        //}
        //public IActionResult Delete(int id)
        //{
        //    customerService.Delete(id);
        //    return RedirectToAction("");
        //}

        [Route("Them-ct-dh")]
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DoAdd(ChiTietDHModel chiTietDHModel)
        {
            customerService.Add(chiTietDHModel);
            return RedirectToAction("");
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
        public IActionResult List()
        {
            if (!isAuthenticated()) return Redirect("login");
            var searchModel = new SearchParam<ChiTietDonHangParam>(1, 20, new ChiTietDonHangParam());

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
