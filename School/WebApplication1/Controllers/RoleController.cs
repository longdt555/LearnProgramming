using Microsoft.AspNetCore.Mvc;
using StoreManagement.Dtos.Respones;
using StoreManagement.Models;
using System.Web.Mvc;
using static StoreManagement.Common.JMessage;

namespace StoreManagement.Controllers
{
    public class RoleController : BaseController
    {
        public IActionResult Save()
        {
            return View();
        }

        public IActionResult DoSave(RoleModel model)
        {
            #region [Validate]

            if (string.IsNullOrEmpty(model.Name))
            {
                return Json(new JsonResDto
                {
                    Success = false,
                    Message = NameRequied
                }, JsonRequestBehavior.AllowGet);
            }

            #endregion [Validate]

            return Json(new
            {
                IsSucces = false,
                data = listError
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
