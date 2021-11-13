using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Context;
using StoreManagement.Dtos;
using StoreManagement.Dtos.Params;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{
    public class DonHangController : BaseController
    {
        private readonly ILogger<DonHangController> _logger;
        private readonly IDonHangService customerService;

        public DonHangController(ILogger<DonHangController> logger, IDonHangService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }

        //[Route("don-hang")]
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

        [Route("DonHang")]
        public IActionResult List(int pageIndex, int pageSize, string trangThaiDonHang)
        {
            if (!isAuthenticated()) return Redirect("404");
            var searchModel = new SearchParam<DonHangParam>(pageIndex, pageSize, new DonHangParam(trangThaiDonHang));
            
            var customers = customerService.GetAll(searchModel);
            return View(customers);

        }

        //public IActionResult Details()
        //{
        //    var customers = customerService.GetDonHangDto();
        //    return View(customers);
        //}

        public IActionResult Delete(int id)
        {
            customerService.Delete(id);
            return RedirectToAction("");
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DoAdd(DonHangModel donHangModel)
        {
            customerService.Add(donHangModel);
            return RedirectToAction("");
        }
        public IActionResult Edit(int id)
        {
            var donHang = customerService.GetById(id);
            return View(donHang);
        }
        public IActionResult DoEdit(DonHangModel donHangModel)
        {
            customerService.Edit(donHangModel);
            return RedirectToAction("");
        }

    }
}
