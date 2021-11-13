using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{
    public class DangNhapController : Controller
    {
        [Route("DangNhap")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
