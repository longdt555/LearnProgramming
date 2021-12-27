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
        private readonly IHangHoaService _service;

        public HangHoaController(ILogger<HangHoaController> logger, IHangHoaService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Add(int id)
        {
            return PartialView("_AddPartial", _service.GetById(id) ?? new HangHoaModel());
        }
        public IActionResult DoAdd(HangHoaModel hangHoaModel)
        {
            if (hangHoaModel.Id == 0)
            {
                _service.Add(hangHoaModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.SaveSuccessfully
                });
            }
            else
            {
                _service.Edit(hangHoaModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.UpdateSuccessfully
                });
            }
        }

        public IActionResult Edit(int id)
        {
            var hangHoa = _service.GetById(id);
            return View(hangHoa);
        }
        public IActionResult DoEdit(HangHoaModel hangHoaModel)
        {
            _service.Edit(hangHoaModel);
            return RedirectToAction("");
        }

        #region 18/11/2021 Hai

        //Hiện thị danh sách 
        [Route("HangHoa")]
        public IActionResult List(int pageIndex, int pageSize, string name)
        {
            if (!isAuthenticated()) return Redirect("login");
            var searchModel = new SearchParam<HangHoaParam>(pageIndex, pageSize, new HangHoaParam(name));

            var customers = _service.GetAll(searchModel);
            return View(customers);
        }

        //Thực hiện tìm kiếm theo tên
        public IActionResult Search(int pageIndex, int pageSize, string name)
        {
            var searchModel = new SearchParam<HangHoaParam>(pageIndex, pageSize, new HangHoaParam(name));

            var customers = _service.GetAll(searchModel);
            return PartialView("~/Views/HangHoa/_ListPartial.cshtml", customers.Data.ToList());
        }

        //Xóa bản ghi và lưu lại thông tin đang tìm kiếm 
        public IActionResult Delete(int pageIndex, int pageSize, string name, int id)
        {
            //delete record
            _service.Delete(id);

            //Sau khi xóa xong thực hiện tìm kiếm lại 
            var searchModel = new SearchParam<HangHoaParam>(pageIndex, pageSize, new HangHoaParam(name));

            var customers = _service.GetAll(searchModel);
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

            var response = _service.GetAll(new SearchParam<HangHoaParam>(1, int.MaxValue, new HangHoaParam()));

            if (response.Data.Any())
            {
                var count = 1;
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

        #endregion

        [HttpPost]
        public JsonResult Import()
        {
            try
            {
                var formFile = Request.Form.Files[0]; // lấy file trong request của người dùng

                #region [Validate]

                if (formFile == null || formFile.Length <= 0)
                {
                    return Json(new JsonResDto
                    {
                        Success = false,
                        Message = JMessage.ImportFailed
                    });
                }

                if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    return Json(new JsonResDto
                    {
                        Success = false,
                        Message = JMessage.ImportFailed
                    });
                }

                #endregion [Validate]

                var data = new List<HangHoaModel>();

                using (var stream = new MemoryStream())
                {
                    formFile.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        var workSheet = package.Workbook.Worksheets.First();
                        var totalRows = workSheet.Dimension.Rows;

                        for (var i = 2; i <= totalRows; i++)
                        {
                            var model = new HangHoaModel()
                            {
                                Id = ConvertHelper.ConvertToInt(workSheet.Cells[i, 1].Value) == 0
                                    ? 0
                                    : _service.GetById(ConvertHelper.ConvertToInt(workSheet.Cells[i, 1].Value))
                                        ?.Id ?? 0,
                                TenHH = workSheet.Cells[i, 2].Value.ToString()
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

                //// gọi service save many

                var res = _service.SaveMany(data);

                if (res < 0)
                    return Json(new JsonResDto
                    {
                        Success = false,
                        Message = JMessage.ImportFailed
                    });
                else
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

        private JsonResult Json()
        {
            throw new NotImplementedException();
        }
    }
}