using FlexWalletSelfService.Web.Abstractions.Models;
using FlexWalletSelfService.Web.Abstractions.Services.Data;
using FlexWalletSelfService.Web.Helpers;
using Newtonsoft.Json;
using System.Text;

namespace FlexWalletSelfService.Web.Services.DataServices
{
    public class AccountDataServices : IAccountDataServices
    {
        readonly IHttpClientFactory httpClientFactory;
        StatusMessage statusMessage = new();
        public AccountDataServices(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<StatusMessage> Login(WalletUserLogin walletUserLogin)
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(walletUserLogin);
                HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/api/Account/Login", contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var events = await response.Content.ReadAsStringAsync();
                }
            }
            catch(Exception ex)
            {

            }
            return statusMessage;
        }

        public async Task<StatusMessage> Registration(WalletUserRegister walletUserRegister)
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(walletUserRegister);
                HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/api/Account/Register", contentPost);
                if (response.IsSuccessStatusCode)
                {
                    
                    var events = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var events = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return statusMessage;
        }
    }
}
