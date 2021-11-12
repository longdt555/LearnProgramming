using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Dtos.Params;
using StoreManagement.IServices;
using StoreManagement.Models;
using System.Diagnostics;
using System.Linq;

namespace StoreManagement.Controllers
{
    public class ChiTietDHController : BaseController
    {
        private readonly ILogger<ChiTietDHController> _logger;
        private readonly IChiTietDHService customerService;

        public ChiTietDHController(ILogger<ChiTietDHController> logger, IChiTietDHService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }
        //[Route("ChiTietDonHang")]

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
        [Route("ChiTietDH")]
        public IActionResult List(int pageIndex, int pageSize, string maDh)
        {
            if (!isAuthenticated()) return Redirect("404");
            var searchModel = new SearchParam<ChiTietDonHangParam>(pageIndex, pageSize, new ChiTietDonHangParam(maDh));

            var customers = customerService.GetAll(searchModel);
            return View(customers);
        }
        //[Route("ChiTietDonHang")]

        //public IActionResult Details()
        //{
        //    var customers = customerService.GetAll();
        //    return View(customers);
        //}
        public IActionResult Delete(int id)
        {
            customerService.Delete(id);
            return RedirectToAction("");
        }

        [Route("Them-ct-dh")]
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DoAdd(ChiTietDHModel chiTietDHModel)
        {
            customerService.Add(chiTietDHModel);
            return RedirectToAction("");
        }
        public IActionResult Edit(int id)
        {
            var chiTietDH = customerService.GetById(id);
            return View(chiTietDH);
        }
        public IActionResult DoEdit(ChiTietDHModel chiTietDHModel)
        {
            customerService.Edit(chiTietDHModel);
            return RedirectToAction("");
        }
    }
}
