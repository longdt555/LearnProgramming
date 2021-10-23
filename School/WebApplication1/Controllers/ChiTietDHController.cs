using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.IServices;
using StoreManagement.Models;
using System.Diagnostics;

namespace StoreManagement.Controllers
{
    public class ChiTietDHController : Controller
    {
        private readonly ILogger<ChiTietDHController> _logger;
        private readonly IChiTietDH customerService;

        public ChiTietDHController(ILogger<ChiTietDHController> logger, IChiTietDH customerService)
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
