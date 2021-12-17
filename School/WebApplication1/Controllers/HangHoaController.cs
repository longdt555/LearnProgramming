using System;
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
                    Message = JMessage.SaveSuccessed
                });
            }
            else
            {
                customerService.Edit(hangHoaModel);
                return Json(new JsonResDto
                {
                    Success = true,
                    Message = JMessage.UpdateSuccessed
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
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Danh_sach_don_hang.xlsx");
                }
            }
        }

        [HttpPost]
        public JsonResult ImportTPDCExcel()
        {
            try
            {
                var file = HttpContext.Request.Form.Files[0];
                //var list = new List<ThanhPhanBaoCaoDiaChatViewModel>();
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
                        int totalRows = workSheet.Dimension.Rows;

                        //for (int i = 2; i <= totalRows; i++)
                        //{
                        //    var model = new ThanhPhanBaoCaoDiaChatViewModel
                        //    {
                        //        ID_KHLT = _BaoCaoDiaChatService.GetByKHLT(ConvertData(DataType.String, workSheet.Cells[i, 9]))?.Id ?? 0,
                        //        CreatedDate = DateTime.Now,
                        //        UpdatedDate = DateTime.Now,
                        //        CreatedBy = LoggedOnUser.UserName,
                        //        UpdatedBy = LoggedOnUser.UserName,
                        //        MaTP = ConvertData(DataType.StringNotNull, workSheet.Cells[i, 1]),
                        //        NhomBaoCao = ConvertData(DataType.String, workSheet.Cells[i, 2]),
                        //        ThanhPhanBaoCao = ConvertData(DataType.String, workSheet.Cells[i, 3]),
                        //        SoLuongTrang = ConvertData(DataType.Int, workSheet.Cells[i, 4]),
                        //        SoLuongAnh = ConvertData(DataType.Int, workSheet.Cells[i, 5]),
                        //        SoLuongBanVe = ConvertData(DataType.Int, workSheet.Cells[i, 6]),
                        //        LoaiThanhPhan = ConvertData(DataType.String, workSheet.Cells[i, 7]),
                        //        File = ConvertData(DataType.String, workSheet.Cells[i, 8]),
                        //    };
                        //    list.Add(model);
                        //    if (WebHelpers.isNullExcelRow(workSheet, i + 1, 8))
                        //    {
                        //        break;
                        //    }
                        //}
                    }

                }
                if (!list.Any()) return Json(new { status = true });
                _thanQuangService.Import(0, list);
                return Json(new { status = true });
            }
            catch (ImportException e)
            {
                _logger.Error($"Error when import: {e.Message} at {e.StackTrace}");
                return Json(new { status = false, message = $"Import không thành công - Sai định dạng dữ liệu tại cell {e.Message}" });
            }
            catch (Exception e)
            {
                _logger.Error($"Error when import: {e.Message} at {e.StackTrace}");
                return Json(new { status = false, message = "Import không thành công." });
            }
        }
        #endregion 18/11/2021 Hai
    }
}