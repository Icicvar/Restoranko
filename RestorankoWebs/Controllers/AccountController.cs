using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Security.Principal;

namespace RestorankoWebs.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }
        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
}
    }
}
