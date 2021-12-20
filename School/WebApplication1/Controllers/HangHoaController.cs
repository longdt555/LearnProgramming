using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.IServices;
using StoreManagement.Models;
using System.Linq;
using StoreManagement.Common;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using StoreManagement.Common.Helpers;
using StoreManagement.Data;

namespace StoreManagement.Controllers
{
    public class HangHoaController : BaseController
    {
        private readonly ILogger<HangHoaController> _logger;
        private readonly IHangHoaService customerService;

        public HangHoaController(ILogger<HangHoaController> logger, IHangHoaService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }

        public IActionResult Add(int id)
        {
            return PartialView("_AddPartial", customerService.GetById(id) ?? new HangHoaModel());
        }
        public IActionResult DoAdd(HangHoaModel hangHoaModel)
        {
            if (hangHoaModel.Id == 0)
            {
                customerService.Add(hangHoaModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.SaveSuccessfully
                });
            }
            else
            {
                customerService.Edit(hangHoaModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.UpdateSuccessfully
                });
            }
        }

        public IActionResult Edit(int id)
        {
            var hangHoa = customerService.GetById(id);
            return View(hangHoa);
        }
        public IActionResult DoEdit(HangHoaModel hangHoaModel)
        {
            customerService.Edit(hangHoaModel);
            return RedirectToAction("");
        }

        #region 18/11/2021 Hai

        //Hiện thị danh sách 
        [Route("HangHoa")]
        public IActionResult List(int pageIndex, int pageSize, string name)
        {
            if (!isAuthenticated()) return Redirect("login");
            var searchModel = new SearchParam<HangHoaParam>(pageIndex, pageSize, new HangHoaParam(name));

            var customers = customerService.GetAll(searchModel);
            return View(customers);
        }

        //Thực hiện tìm kiếm theo tên
        public IActionResult Search(int pageIndex, int pageSize, string name)
        {
            var searchModel = new SearchParam<HangHoaParam>(pageIndex, pageSize, new HangHoaParam(name));

            var customers = customerService.GetAll(searchModel);
            return PartialView("~/Views/HangHoa/_ListPartial.cshtml", customers.Data.ToList());
        }

        //Xóa bản ghi và lưu lại thông tin đang tìm kiếm 
        public IActionResult Delete(int pageIndex, int pageSize, string name, int id)
        {
            //delete record
            customerService.Delete(id);

            //Sau khi xóa xong thực hiện tìm kiếm lại 
            var searchModel = new SearchParam<HangHoaParam>(pageIndex, pageSize, new HangHoaParam(name));

            var customers = customerService.GetAll(searchModel);
            return PartialView("~/Views/HangHoa/_ListPartial.cshtml", customers.Data.ToList());
        }

        /// <summary>
        /// CloseXML: Thao tác excel
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FileResult Export()
        {
            var dbTable = new DataTable("Danh sách hàng hóa");

            dbTable.Columns.AddRange(new DataColumn[] {
                                            new DataColumn("Số thứ tự"),
                                            new DataColumn("Tên hàng hóa"),
                                            new DataColumn("Số lượng"),
                                            new DataColumn("Đơn giá"),
                                            new DataColumn("Chi tiết hàng hóa")
                                        });

            var response = customerService.GetAll(new SearchParam<HangHoaParam>(1, int.MaxValue, new HangHoaParam()));

            if (response.Data.Any())
            {
                var count = 0;
                foreach (var item in response.Data)
                {
                    dbTable.Rows.Add(count, item.TenHH, item.SoLuong, item.DonGia, item.ChiTiet);
                    count++;
                }
            }

            using (var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dbTable);
                using (var stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Danh_sach_hang-hoa.xlsx");
                }
            }
        }
    }
}
#endregion
//    [HttpPost]
//    public JsonResult ImportTPDCExcel()
//    {
//        try
//        {
//            var file = HttpContext.Request.Form.Files[0];
//            //var list = new List<ThanhPhanBaoCaoDiaChatViewModel>();
//            using (var stream = new MemoryStream())
//            {
//                file.CopyTo(stream);
//                using (var package = new ExcelPackage(stream))
//                {
//                    ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
//                    int totalRows = workSheet.Dimension.Rows;

        [HttpPost]
        public JsonResult Import(IFormFile formData)
        {
            try
            {
                var data = new List<HangHoaModel>();
                using (var stream = new MemoryStream())
                {
                    formData.CopyTo(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        var workSheet = package.Workbook.Worksheets.First();
                        var totalRows = workSheet.Dimension.Rows;

                        for (var i = 2; i <= totalRows; i++)
                        {
                            var model = new HangHoaModel()
                            {
                                Id = customerService.GetById(ConvertHelper.ConvertToInt(workSheet.Cells[i, 1]))?.Id ?? 0,
                                TenHH = workSheet.Cells[i, 2].ToString()
                            };
                            data.Add(model);
                        }
                    }
                }

                if (!data.Any()) return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.ImportSuccessfully
                });

                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.ImportSuccessfully
                });
            }
            catch (Exception e)
            {
                return Json(new JsonResDto
                {
                    Success = false,
                    Message = JMessage.ImportFailed
                });
            }
        }
        #endregion 18/11/2021 Hai
    }
}