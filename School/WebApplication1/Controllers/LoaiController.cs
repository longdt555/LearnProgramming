using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.IServices;
using StoreManagement.Models;
using StoreManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList.Mvc;

using PagedList;

namespace StoreManagement.Controllers
{
    public class LoaiController : Controller
    {
        private readonly ILogger<LoaiController> _logger;
        private readonly ILoaiService customerService;

        public LoaiController(ILogger<LoaiController> logger, ILoaiService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }
        public IActionResult Index( int? page)
        {
            var customers = customerService.GetAll().ToList().ToPagedList(page ?? 1, 5);
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

        public IActionResult DoAdd(LoaiModel loaiModel)
        {
            customerService.Add(loaiModel);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var loai = customerService.GetById(id);
            if (loai == null) return BadRequest();
            return View(loai);
        }

        public IActionResult DoEdit(LoaiModel loaiModel)
        {

            customerService.Edit(loaiModel);
            return RedirectToAction("Index");
        }


    }
}
