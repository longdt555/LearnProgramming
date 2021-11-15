using Microsoft.AspNetCore.Mvc;

namespace StoreManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("404")]
        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}
