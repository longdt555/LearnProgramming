using Microsoft.AspNetCore.Mvc;
using StoreManagement.Dtos.Respones;
using StoreManagement.Models;
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
                    Message = NameRequired
                });
            }

            #endregion [Validate]

            return Json(new JsonResDto
            {
                Success = true,
                Data = model.Name
            });
        }
    }
}