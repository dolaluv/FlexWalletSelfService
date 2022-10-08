using FlexWalletSelfService.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FlexWalletSelfService.Web.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            return View();
        }

    }
}
