using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Common;
using StoreManagement.Context;
using StoreManagement.Dtos;
using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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

        public IActionResult Add(int id)
        {
            return PartialView("_AddPartial", customerService.GetById(id) ?? new DonHangModel());
        }
        public IActionResult DoAdd(DonHangModel donHangModel)
        {
            if (donHangModel.Id == 0)
            {
                customerService.Add(donHangModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.SaveSuccessfully
                });
            }
            else
            {
                customerService.Edit(donHangModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.UpdateSuccessfully
                });
            }
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
        public IActionResult List(int pageIndex, int pageSize, string TrangThaiDonHang)
        {
            if (!isAuthenticated()) return Redirect("login");
            var searchModel = new SearchParam<DonHangParam>(pageIndex, pageSize, new DonHangParam(TrangThaiDonHang));

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
        public IActionResult Delete(int pageIndex, int pageSize, string TrangThaiDonHang, int id)
        {
            //delete record
            customerService.Delete(id);

            //Sau khi xóa xong thực hiện tìm kiếm lại
            var searchModel = new SearchParam<DonHangParam>(pageIndex, pageSize, new DonHangParam(TrangThaiDonHang));
            var customers = customerService.GetAll(searchModel);
            return PartialView("~/Views/DonHang/_ListPartial.cshtml", customers.Data.ToList());

        }

        #endregion [18/11/2021] Hai

        ///<summary>
        /// CloseXML: Thao tác excel
        /// </summary>
        [HttpGet]
        public FileResult Export()
        {
            var dbTable = new DataTable("Danh sách đơn hàng");

            dbTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Số thứ tự"),
                new DataColumn("Phí vận chuyển"),
                new DataColumn("Tổng tiền"),
                new DataColumn("Trạng thái đơn hàng"),
                new DataColumn("Trạng thái thanh toán")
            });

            var response = customerService.GetAll(new SearchParam<DonHangParam>(1, int.MaxValue, new DonHangParam()));

            if (response.Data.Any())
            {
                var count = 1;
                foreach (var item in response.Data)
                {
                    dbTable.Rows.Add(count, item.PhiVanChuyen, item.TongTien, item.TrangThaiDonHang, item.TrangThaiThanhToan);
                }
            }

            using(var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dbTable);
                using(var stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Danh_sach_don_hang.xlsx");
                }
            }
        }

    }
}
