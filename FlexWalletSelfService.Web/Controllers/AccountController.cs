using FlexWalletSelfService.Web.Abstractions.Models;
using FlexWalletSelfService.Web.Abstractions.Services.Business;
using FlexWalletSelfService.Web.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FlexWalletSelfService.Web.Controllers
{
    public class AccountController : Controller
    {
        readonly IAccountServices accountServices;
        ProtectedSessionStorage LocalStorage;

        public AccountController(IAccountServices accountServices )
        {
            this.accountServices = accountServices ?? throw new ArgumentNullException(nameof(accountServices));
            
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Register(WalletUserRegister walletUserRegister)
        {
            ViewBag.Message = string.Empty;
            var result = await this.accountServices.WalletRegistration(walletUserRegister);
            ViewBag.Message = result.Status ? "Your Registration was successful. Click Below to Login" : result.Message;

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(WalletUserLogin loginModel)
        {

            ViewBag.Message = string.Empty;
            var result = await this.accountServices.WalletLogin(loginModel);
            if (result.Status)
            {
                HttpContext.Session.SetString("Token", result.Message);
              
                
               
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            ViewBag.Message = result.Message;

            return View();
        }
      

    }
}
