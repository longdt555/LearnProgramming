using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.IServices;
using StoreManagement.Models;

namespace StoreManagement.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly ILogger<HangHoaController> _logger;
        private readonly IHangHoaService customerService;

        public HangHoaController(ILogger<HangHoaController> logger, IHangHoaService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }
        [Route("hh")]
        [Route("hanghoa")]
        public IActionResult Index()
        {
            var customers = customerService.GetAll();
            return View(customers);
        }
        //public IActionResult Details()
        //{
        //    var customers = customerService.GetHangHoaDto();
        //    return View(customers);
        //}
        public IActionResult Delete(int id)
        {
            customerService.Delete(id);
            return RedirectToAction("index");
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DoAdd(HangHoaModel hangHoaModel)
        {
            customerService.Add(hangHoaModel);
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            var hangHoa = customerService.GetById(id);
            return View(hangHoa);
        }
        public IActionResult DoEdit(HangHoaModel hangHoaModel)
        {
            customerService.Edit(hangHoaModel);
            return RedirectToAction("index");
        }
    }
}