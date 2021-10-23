﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.IServices;

namespace StoreManagement.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly ILogger<HangHoaController> _logger;
        private readonly IHangHoa customerService;

        public HangHoaController(ILogger<HangHoaController> logger, IHangHoa customerService)
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
