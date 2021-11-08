using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Models;
using StoreManagement.Services;
using Microsoft.Extensions.Logging;
using StoreManagement.IServices;

namespace StoreManagement.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login(AccountModel acc)
        {
            return View();
        }


    }
}
