using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Context;
using StoreManagement.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{
    public class DonHangController : Controller
    {
        private readonly ILogger<DonHangController> _logger;
        private readonly IDonHang customerService;

        public DonHangController(ILogger<DonHangController> logger, IDonHang customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }
        public IActionResult Index()
        {
            using (var db = new SMDBContext())
            {
                //var list = db.DonHangs.Include("khachhang").ToList();
                //return View(list);

                var customers = customerService.GetAll();
                return View(customers);
            }
    

        }

    }
}
