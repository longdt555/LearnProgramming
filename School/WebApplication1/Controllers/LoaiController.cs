﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.IServices;
using StoreManagement.Models;
using System.Linq;
using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.Common;

namespace StoreManagement.Controllers
{
    public class LoaiController : BaseController
    {
        private readonly ILogger<LoaiController> _logger;
        private readonly ILoaiService _service;

        public LoaiController(ILogger<LoaiController> logger, ILoaiService customerService)
        {
            _logger = logger;
            this._service = customerService;
        }

        public IActionResult Add(int id)
        {
            return PartialView("_AddPartial", _service.GetById(id) ?? new LoaiModel());
        }

        public IActionResult DoAdd(LoaiModel loaiModel)
        {
            if (loaiModel.Id == 0)
            {
                _service.Add(loaiModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.SaveSuccessed
                });
            }
            else
            {
                _service.Edit(loaiModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.UpdateSuccessed
                });
            }

        }

        public IActionResult Edit(int id)
        {
            return PartialView("_AddPartial", _service.GetById(id) ?? new LoaiModel());
        }

        public IActionResult DoEdit(LoaiModel loaiModel)
        {
            _service.Edit(loaiModel);
            //return RedirectToAction("");
            return Redirect("List");

        }

        #region Hai

        [Route("Loai")]
        public IActionResult List(int pageIndex, int pageSize, string name)
        {
            if (!isAuthenticated()) return Redirect("login");

            var searchModel = new SearchParam<LoaiParam>(pageIndex, pageSize, new LoaiParam(name));
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
    }
}


// code thừa -> bỏ : dối, source control (git)

// chia khối: nhìn cho dễ hiểu, dễ đọc, dễ sửa