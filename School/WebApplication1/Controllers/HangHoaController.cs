using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Dtos.Params;
using StoreManagement.Dtos.Respones;
using StoreManagement.IServices;
using StoreManagement.Models;
using System.Linq;
using StoreManagement.Common;

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
        public IActionResult List()
        {
            if (!isAuthenticated()) return Redirect("login");
            var searchModel = new SearchParam<HangHoaParam>(1, 20, new HangHoaParam());

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
        #endregion 18/11/2021 Hai
    }
}