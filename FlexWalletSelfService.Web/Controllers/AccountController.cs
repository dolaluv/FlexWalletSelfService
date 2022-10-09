using FlexWalletSelfService.Web.Abstractions.Models;
using FlexWalletSelfService.Web.Abstractions.Services.Business;
using FlexWalletSelfService.Web.Helpers;
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

        public AccountController(IAccountServices accountServices)
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
            var result = await this.accountServices.WalletRegistration(walletUserRegister);
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(WalletUserLogin loginModel)
        {

          var result = await this.accountServices.WalletLogin(loginModel);
          


            return View();
        }
      

    }
}
