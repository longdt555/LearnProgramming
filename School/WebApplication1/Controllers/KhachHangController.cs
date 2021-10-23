using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ILogger<KhachHangController> _logger;
        private readonly IKhachHang customerService;

        public KhachHangController(ILogger<KhachHangController> logger, IKhachHang customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }
        public IActionResult Index()
        {
            var customers = customerService.GetAll();
            return View(customers);
        }
    }
}
