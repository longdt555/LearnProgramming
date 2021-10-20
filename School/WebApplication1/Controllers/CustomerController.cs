using Microsoft.AspNetCore.Mvc;
using StoreManagement.IServices;

namespace StoreManagement.Controllers
{
    public class CustomerController : Controller
    {
        #region [Params]

        private readonly ICustomerService _customerService;

        #endregion  [Params]

        #region [Constuctor]
        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        #endregion [Constuctor]


        public IActionResult Index()
        {
            var customers = _customerService.GetAll();
            return View(customers);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
