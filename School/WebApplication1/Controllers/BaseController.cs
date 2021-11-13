using Microsoft.AspNetCore.Mvc;
using StoreManagement.Data;
using StoreManagement.Common.Helpers;

namespace StoreManagement.Controllers
{
    public class BaseController : Controller
    {
        public bool isAuthenticated() => !LoggedOnUser.Get().IsNull();
        

    }
}
