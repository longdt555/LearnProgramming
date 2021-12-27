using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Common;
using StoreManagement.Context;
using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{

    public class KhachHangController : BaseController
    {
        private readonly ILogger<KhachHangController> _logger;
        private readonly IKhachHangService customerService;

        public KhachHangController(ILogger<KhachHangController> logger, IKhachHangService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }

        public IActionResult Add(int id)
        {
            return PartialView("_AddPartial", customerService.GetById(id) ?? new KhachHangModel());
        }
        public IActionResult DoAdd(KhachHangModel khachHangModel)
        {
            if (khachHangModel.Id == 0)
            {
                customerService.Add(khachHangModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.SaveSuccessfully
                });
            }
            else
            {
                customerService.Edit(khachHangModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.SaveSuccessfully
                });
            }

        }

        public PartialViewResult Edit(int id)
        {
            var khachHang = customerService.GetById(id);
            return PartialView(khachHang);
        }

        public JsonResult Edit(KhachHangModel khachHangModel)
        {
            customerService.Edit(khachHangModel);
            return Json(khachHangModel, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        #region [18/11/2021]

        /// <summary>
        /// Hiển thị danh sách người dùng mặc định
        /// </summary>
        /// <returns></returns>
        [Route("KhachHang")]
        public IActionResult ListKhachHang(int pageIndex, int pageSize, string name)
        {
            if (!isAuthenticated()) return Redirect("login");
            var searchModel = new SearchParam<KhachHangParam>(pageIndex, pageSize, new KhachHangParam(name));  //TEST

            var customers = customerService.GetAll(searchModel);
            return View(customers);

        }


        public IActionResult Search(int pageIndex, int pageSize, string name)
        {
            var searchModel = new SearchParam<KhachHangParam>(pageIndex, pageSize, new KhachHangParam(name));

            var customers = customerService.GetAll(searchModel);
            return PartialView("~/Views/KhachHang/_ListPartial.cshtml", customers.Data.ToList());
        }


        public IActionResult Delete(int pageIndex, int pageSize, string name, int id)
        {
            // delete record
            customerService.Delete(id);

            // Sau khi xóa xong thực hiện tìm kiếm lại
            var searchModel = new SearchParam<KhachHangParam>(pageIndex, pageSize, new KhachHangParam(name));
            var customers = customerService.GetAll(searchModel);
            return PartialView("~/Views/KhachHang/_ListPartial.cshtml", customers.Data.ToList());
        }

        #endregion [18/11/2021]

        ///<summary>
        /// CloseXML: Thao tác excel
        /// </summary>
        [HttpGet]
        public FileResult Export()
        {
            var dbTable = new DataTable("Danh sách khách hàng");

            dbTable.Columns.AddRange(new DataColumn[] {
                new DataColumn("Số thứ tự"),
                new DataColumn("Họ tên"),
                new DataColumn("Email"),
                new DataColumn("Đang hoạt động"),
                new DataColumn("Nhận quảng cáo")
            });

            var response = customerService.GetAll(new SearchParam<KhachHangParam>(1, int.MaxValue, new KhachHangParam()));

            if (response.Data.Any())
            {
                var count = 1;
                foreach (var item in response.Data)
                {
                    dbTable.Rows.Add(count, item.HoTen, item.Email, item.DangHoatDong, item.NhanQuangCao);
                    count++;
                }
            }

            using(var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dbTable);
                using(var stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Danh_sach_khach_hang.xlsx");
                }
            }
        }
    }
}
