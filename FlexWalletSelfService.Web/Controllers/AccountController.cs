﻿using Microsoft.AspNetCore.Mvc;

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

    }
}