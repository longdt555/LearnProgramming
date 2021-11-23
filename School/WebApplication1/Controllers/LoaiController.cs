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


        public IActionResult Add()
        {
            return RedirectToAction("_AddParital");
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


        #region Hai

        [Route("Loai")]
        public IActionResult List()
        {
            if (!isAuthenticated()) return Redirect("login");
            var searchModel = new SearchParam<LoaiParam>(1, 20, new LoaiParam());  //TEST

            var customers = _service.GetAll(searchModel);
            return View(customers);

        }


        public IActionResult Search(int pageIndex, int pageSize, string name)
        {
            var searchModel = new SearchParam<LoaiParam>(pageIndex, pageSize, new LoaiParam(name));

            var customers = _service.GetAll(searchModel);
            return PartialView("~/Views/Loai/_ListPartial.cshtml", customers.Data.ToList());
        }

      
        public IActionResult Delete(int pageIndex, int pageSize, string name, int id)
        {
            // delete record
            _service.Delete(id);

            // Sau khi xóa xong thực hiện tìm kiếm lại
            var searchModel = new SearchParam<LoaiParam>(pageIndex, pageSize, new LoaiParam(name));
            var customers = _service.GetAll(searchModel);
            return PartialView("~/Views/Loai/_ListPartial.cshtml", customers.Data.ToList());
        }
        #endregion Hai

        //#region add edit

        //public ActionResult AddEdit(int id)
        //{
        //    LoaiModel loaiModel = new LoaiModel();
        //    if (id > 0)
        //    {
        //        _service.Edit(loaiModel);
        //    }

        //    return PartialView("Partial2", loaiModel);
        //}

        //#endregion
    }

}

