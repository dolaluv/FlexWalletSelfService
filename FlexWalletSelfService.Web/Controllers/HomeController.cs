﻿using FlexWalletSelfService.Web.Abstractions.Models;
using FlexWalletSelfService.Web.Abstractions.Services.Business;
using FlexWalletSelfService.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlexWalletSelfService.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWalletTransactionServices walletTransactionServices;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IWalletTransactionServices walletTransactionServices, ILogger<HomeController> logger)
        {
            this.walletTransactionServices = walletTransactionServices ?? throw new ArgumentNullException(nameof(walletTransactionServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> Index()
        {
            var tok = HttpContext.Session.GetString("Token");
            await this.walletTransactionServices.GetAccountBalance("");
            return View();
        }

        public IActionResult FundTransfer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FundTransfer(WalletFundTransfer walletFund)
        {
            await this.walletTransactionServices.FundTransfer(walletFund);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}