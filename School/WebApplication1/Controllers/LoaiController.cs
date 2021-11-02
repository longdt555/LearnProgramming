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
        private readonly ILoaiService _customerService;

        public LoaiController(ILogger<LoaiController> logger, ILoaiService customerService)
        {
            _logger = logger;
            this._customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetAll().ToList();
            return View(customers);
        }

        public IActionResult Delete(int id)
        {
            _customerService.Delete(id);
            return RedirectToAction("index");
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult DoAdd(LoaiModel loaiModel)
        {
            _customerService.Add(loaiModel);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var loai = _customerService.GetById(id);
            if (loai == null) return BadRequest();
            return View(loai);
        }

        public IActionResult DoEdit(LoaiModel loaiModel)
        {

            _customerService.Edit(loaiModel);
            return RedirectToAction("Index");
        }


    }
}
