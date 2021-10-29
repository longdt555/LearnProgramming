using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Context;
using StoreManagement.Dtos;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{
    public class DonHangController : Controller
    {
        private readonly ILogger<DonHangController> _logger;
        private readonly IDonHangService customerService;

        public DonHangController(ILogger<DonHangController> logger, IDonHangService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }

        [Route("don-hang")]
        public IActionResult Index()
        {
            var customers = customerService.GetAll();
            return View(customers);
        }

        public IActionResult Details()
        {
            var customers = customerService.GetDonHangDto();
            return View(customers);
        }

        public IActionResult Delete(int id)
        {
            customerService.Delete(id);
            return RedirectToAction("index");
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DoAdd(DonHangModel donHangModel)
        {
            customerService.Add(donHangModel);
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            var donHang = customerService.GetById(id);
            return View(donHang);
        }
        public IActionResult DoEdit(DonHangModel donHangModel)
        {
            customerService.Edit(donHangModel);
            return RedirectToAction("index");
        }

    }
}
