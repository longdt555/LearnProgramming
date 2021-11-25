using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Context;
using StoreManagement.Dtos.Params;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{

    public class KhachHangController : BaseController
    {
        private readonly ILogger<KhachHangController> _logger;
        private readonly IKhachHangService customerService;

        public KhachHangController(ILogger<KhachHangController> logger, IKhachHangService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }

        public IActionResult Index(int pg = 1)
        {
            var customers = customerService.GetAll().ToList();
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

        public IActionResult Add(int id)
        {
            return PartialView("_AddPartial",customerService.GetById(id) ?? new KhachHangModel());
        }
        public IActionResult DoAdd(KhachHangModel khachHangModel)
        {
            customerService.Add(khachHangModel);
            return Redirect("List");
        }
        //public IActionResult Edit(int id)
        //{
        //    var khachHang = customerService.GetById(id);
        //    if (khachHang == null) return BadRequest();
        //    return View(khachHang);
        //}
        //public IActionResult DoEdit(KhachHangModel khachHangModel)
        //{
        //    customerService.Edit(khachHangModel);
        //    return RedirectToAction("");
        //}
        public PartialViewResult Edit(int id)
        {
            var khachHang = customerService.GetById(id);
            //if (khachHang == null) return BadRequest();
            return PartialView(khachHang);
        }

        public JsonResult Edit(KhachHangModel khachHangModel)
        {
            customerService.Edit(khachHangModel);
            return Json(khachHangModel, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        #region [18/11/2021]

        /// <summary>
        /// Hiển thị danh sách người dùng mặc định
        /// </summary>
        /// <returns></returns>
        [Route("KhachHang")]
        public IActionResult ListKhachHang()
        {
            if (!isAuthenticated()) return Redirect("login");
            var searchModel = new SearchParam<KhachHangParam>(1, 20, new KhachHangParam());  //TEST

            var customers = customerService.GetAll(searchModel);
            return View(customers);

        }

       
        public IActionResult Search(int pageIndex, int pageSize, string name)
        {
            var searchModel = new SearchParam<KhachHangParam>(pageIndex, pageSize, new KhachHangParam(name));

            var customers = customerService.GetAll(searchModel);
            return PartialView("~/Views/KhachHang/_ListPartial.cshtml", customers.Data.ToList());
        }

        
        public IActionResult Delete(int pageIndex, int pageSize, string name, int id)
        {
            // delete record
            customerService.Delete(id);

            // Sau khi xóa xong thực hiện tìm kiếm lại
            var searchModel = new SearchParam<KhachHangParam>(pageIndex, pageSize, new KhachHangParam(name));
            var customers = customerService.GetAll(searchModel);
            return PartialView("~/Views/KhachHang/_ListPartial.cshtml", customers.Data.ToList());
        }

        #endregion [18/11/2021]
    }
}
