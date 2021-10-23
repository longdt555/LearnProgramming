using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{
    public class LoaiController : Controller
    {
        private readonly ILogger<LoaiController> _logger;
        private readonly ILoai customerService;

        public LoaiController(ILogger<LoaiController> logger, ILoai customerService)
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
