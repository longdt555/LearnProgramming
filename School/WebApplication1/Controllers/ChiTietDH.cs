using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.IServices;
using StoreManagement.Models;
using System.Diagnostics;

namespace StoreManagement.Controllers
{
    public class ChiTietDH : Controller
    {
        private readonly ILogger<ChiTietDH> _logger;
        private readonly IChiTietDH customerService;

        public ChiTietDH(ILogger<ChiTietDH> logger, IChiTietDH customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
