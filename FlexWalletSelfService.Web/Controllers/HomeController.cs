using FlexWalletSelfService.Web.Abstractions.Models;
using FlexWalletSelfService.Web.Abstractions.Services.Business;
using FlexWalletSelfService.Web.Helpers;
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
            
            var TokenPayLoad = TokeDecode.ProcessToken(HttpContext.Session.GetString("Token"));
            if(TokenPayLoad == null || TokenPayLoad?.AccountNumber == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "Account");
            }
           var LoginUser =  await this.walletTransactionServices.GetAccountBalance(TokenPayLoad.AccountNumber, HttpContext.Session.GetString("Token"));
            return View(LoginUser);
        }

        public IActionResult FundTransfer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FundTransfer(WalletFundTransfer walletFund)
        {
            var TokenPayLoad = TokeDecode.ProcessToken(HttpContext.Session.GetString("Token"));
            if (TokenPayLoad == null || TokenPayLoad?.AccountNumber == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "Account");
            }
            walletFund.AccountmNumber = TokenPayLoad.AccountNumber;
            walletFund.TransactionType = "Fund Transfer";
            ViewBag.Message = string.Empty;
           var result = await this.walletTransactionServices.FundTransfer(walletFund, HttpContext.Session.GetString("Token"));
            ViewBag.Message = result.Status ? "Fund Transfer was Successfully" : result.Message;


            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(actionName: "Login", controllerName: "Account");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}