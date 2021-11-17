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
using StoreManagement.Dtos.Params;
using StoreManagement.Context;

namespace StoreManagement.Controllers
{

    public class LoaiController : BaseController
    {

        private readonly ILogger<LoaiController> _logger;
        private readonly ILoaiService _service;

        SMDBContext db = new SMDBContext();

        public LoaiController(ILogger<LoaiController> logger, ILoaiService customerService)
        {
            _logger = logger;
            this._service = customerService;
        }
    
        public IActionResult Index(int pg = 1)
        {
            var customers = _service.GetAll().ToList();
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

        [Route("Loai")]
        public IActionResult List(int pageIndex, int pageSize, string name)
        {
            if (!isAuthenticated()) return Redirect("404");
            var searchModel = new SearchParam<LoaiParam>(pageIndex, pageSize, new LoaiParam(name));  //TEST
           
            var customers = _service.GetAll(searchModel);
            return View(customers);

        }
        //public ActionResult Search(string searchString)
        //{
        //    var search = _service.Search(searchString);
        //    return View(search);
        //}


        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Partial1");

        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult DoAdd(LoaiModel loaiModel)
        {
            _service.Add(loaiModel);
            return RedirectToAction("");
        }
        public IActionResult Edit(int id)
        {
            var loai = _service.GetById(id);
            if (loai == null) return BadRequest();
            return View(loai);
        }

        public IActionResult DoEdit(LoaiModel loaiModel)
        {

            _service.Edit(loaiModel);
            return RedirectToAction("");
        }

        //public IActionResult Delete(int id)
        //{
        //    _service.Delete(id);

        //    return PartialView("Partial1");
        //}


    }
}
