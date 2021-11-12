using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [Route("KhachHang")]
        public IActionResult ListKhachHang(int pageIndex, int pageSize, string name)
        {
            if (!isAuthenticated()) return Redirect("404");
            var searchModel = new SearchParam<KhachHangParam>(pageIndex, pageSize, new KhachHangParam(name));  //TEST
          
            var customers = customerService.GetAll(searchModel);
            return View(customers);

        }
        public IActionResult Delete(int id)
        {
            customerService.Delete(id);
            return RedirectToAction("");
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DoAdd(KhachHangModel khachHangModel)
        {
            customerService.Add(khachHangModel);
            return RedirectToAction("");
        }
        public IActionResult Edit(int id)
        {
            var khachHang = customerService.GetById(id);
            if (khachHang == null) return BadRequest();
            return View(khachHang);
        }
        public IActionResult DoEdit(KhachHangModel khachHangModel)
        {
            customerService.Edit(khachHangModel);
            return RedirectToAction("");
        }
    }
}