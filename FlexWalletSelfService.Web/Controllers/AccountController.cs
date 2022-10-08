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
        readonly IHttpClientFactory httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
           

            await  ApiCall(loginModel);


            return View();
        }
        public async Task ApiCall(LoginModel loginModel)
        {
            //HttpClient client = new HttpClient();//http://localhost:5119 
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5119");
            var json = JsonConvert.SerializeObject(loginModel);
            HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/Account/Login", contentPost);
            if (response.IsSuccessStatusCode)
            {
              var  events = await response.Content.ReadAsStringAsync();
            }
           

        }

    }
}
