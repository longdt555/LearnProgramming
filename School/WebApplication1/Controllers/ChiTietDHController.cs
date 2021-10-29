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
        private readonly IChiTietDHService customerService;

        public ChiTietDHController(ILogger<ChiTietDHController> logger, IChiTietDHService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }
        public IActionResult Index()
        {
            var customers = customerService.GetAll();
            return View(customers);
        }
        public IActionResult Details()
        {
            var customers = customerService.GetChiTietDHDto();
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
        public IActionResult DoAdd(ChiTietDHModel chiTietDHModel)
        {
            customerService.Add(chiTietDHModel);
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            var chiTietDH = customerService.GetById(id);
            return View(chiTietDH);
        }
        public IActionResult DoEdit(ChiTietDHModel chiTietDHModel)
        {
            customerService.Edit(chiTietDHModel);
            return RedirectToAction("index");
        }
    }
}
