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
            WalletUserAccount walletUserAccount = new();
            try
            {
                var client = httpClientFactory.CreateClient(); 
                HttpResponseMessage response = await client.GetAsync("/api/FundTransaction/GetWallectAccountBalanceByAccountNumber");
                if (response.IsSuccessStatusCode)
                {
                    walletUserAccount = await response.Content.ReadAsAsync<WalletUserAccount>();
                   
                }
            }
            catch (Exception ex)
            {

            }
            return walletUserAccount;
        }

        public async Task<StatusMessage> Transfer(WalletFundTransfer walletFundTransfer)
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(walletFundTransfer);
                HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/api/FundTransaction/FundTransfer", contentPost);
                if (response.IsSuccessStatusCode)
                {
                    statusMessage = await response.Content.ReadAsAsync<StatusMessage>();
                }
            }
            catch (Exception ex)
            {

            }
            return statusMessage;
        }
    }
}
