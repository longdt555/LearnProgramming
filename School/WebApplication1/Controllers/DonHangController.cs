﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Context;
using StoreManagement.Dtos;
using StoreManagement.Dtos.Params;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{
    public class DonHangController : BaseController
    {
        private readonly ILogger<DonHangController> _logger;
        private readonly IDonHangService customerService;

        public DonHangController(ILogger<DonHangController> logger, IDonHangService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }


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
            return View();
        }

     
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DoAdd(DonHangModel donHangModel)
        {
            customerService.Add(donHangModel);
            return RedirectToAction("");
        }
        public IActionResult Edit(int id)
        {
            var donHang = customerService.GetById(id);
            return View(donHang);
        }
        public IActionResult DoEdit(DonHangModel donHangModel)
        {
            customerService.Edit(donHangModel);
            return RedirectToAction("");
        }

        #region [18/11/2021] Hai

        // Hiển thị danh sách người dùng mặc định

        [Route("DonHang")]
        public IActionResult List()
        {
            if (!isAuthenticated()) return Redirect("login");
            var searchModel = new SearchParam<DonHangParam>(1, 20, new DonHangParam());

            var customers = customerService.GetAll(searchModel);
            return View(customers);
        }

        //Thực hiện tìm kiếm theo tên
        public IActionResult Search(int pageIndex, int pageSize, string TrangThaiDonHang)
        {
            var searchModel = new SearchParam<DonHangParam>(pageIndex, pageSize, new DonHangParam(TrangThaiDonHang));

            var customers = customerService.GetAll(searchModel);
            return PartialView("_ListPartial", customers.Data.ToList());
        }

        //Xoá bản ghi và lưu lại các thông tin đang tìm kiếm 
        public IActionResult Delete(int pageIndex, int pageSize,string TrangThaiDonHang, int id)
        {
            //delete record
            customerService.Delete(id);

            //Sau khi xóa xong thực hiện tìm kiếm lại
            var searchModel = new SearchParam<DonHangParam>(pageIndex, pageSize, new DonHangParam(TrangThaiDonHang));
            var customers = customerService.GetAll(searchModel);
            return PartialView("~/Views/DonHang/_ListPartial.cshtml", customers.Data.ToList());

        }
        #endregion [18/11/2021] Hai

    }
}
