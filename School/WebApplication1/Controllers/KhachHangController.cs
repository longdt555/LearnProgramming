using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{
    
    public class KhachHangController : Controller
    {
        private readonly ILogger<KhachHangController> _logger;
        private readonly IKhachHangService customerService;

        public KhachHangController(ILogger<KhachHangController> logger, IKhachHangService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }
        
        [Route("khach-hang")]
        public IActionResult Index(int pagingIndex, int pageSize)
        {
            var customers = customerService.GetAll();
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
        public IActionResult DoAdd(KhachHangModel khachHangModel)
        {
            customerService.Add(khachHangModel);
            return RedirectToAction("index");
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
            return RedirectToAction("index");
        }
    }
}
