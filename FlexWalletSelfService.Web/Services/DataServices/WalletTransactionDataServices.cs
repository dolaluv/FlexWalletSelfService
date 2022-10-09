using FlexWalletSelfService.Web.Abstractions.Models;
using FlexWalletSelfService.Web.Abstractions.Services.Data;
using Newtonsoft.Json;
using System.Text;

namespace FlexWalletSelfService.Web.Services.DataServices
{
    public class WalletTransactionDataServices : IWalletTransactionDataServices
    {
        readonly IHttpClientFactory httpClientFactory;
        StatusMessage statusMessage = new();

        public WalletTransactionDataServices(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<WalletUserAccount> Balance(string WallectAccountNumber)
        {
            try
            {
                var client = httpClientFactory.CreateClient(); 
                HttpResponseMessage response = await client.GetAsync("/api/Account/Login");
                if (response.IsSuccessStatusCode)
                {
                    var events = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return new WalletUserAccount();
        }

        public async Task<StatusMessage> Transfer(WalletFundTransfer walletFundTransfer)
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(walletFundTransfer);
                HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/api/Account/Login", contentPost);
                if (response.IsSuccessStatusCode)
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
