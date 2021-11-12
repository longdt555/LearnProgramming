using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Dtos.Params;
using StoreManagement.IServices;
using StoreManagement.Models;
using System.Linq;

namespace StoreManagement.Controllers
{
    public class HangHoaController : BaseController
    {
        private readonly ILogger<HangHoaController> _logger;
        private readonly IHangHoaService customerService;

        public HangHoaController(ILogger<HangHoaController> logger, IHangHoaService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }
        //[Route("hh")]
        //[Route("hanghoa")]
        public IActionResult Index(int pg = 1)
        {
            var customers = customerService.GetAll();
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
        [Route("HangHoa")]
        public IActionResult List(int pageIndex, int pageSize,string name)
        {
            if (!isAuthenticated()) return Redirect("404");
            var searchModel = new SearchParam<HangHoaParam>(pageIndex, pageSize, new HangHoaParam(name));
            
            var customers = customerService.GetAll(searchModel);
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
            return RedirectToAction("");
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DoAdd(HangHoaModel hangHoaModel)
        {
            customerService.Add(hangHoaModel);
            return RedirectToAction("");
        }
        public IActionResult Edit(int id)
        {
            var hangHoa = customerService.GetById(id);
            return View(hangHoa);
        }
        public IActionResult DoEdit(HangHoaModel hangHoaModel)
        {
            customerService.Edit(hangHoaModel);
            return RedirectToAction("");
        }
    }
}