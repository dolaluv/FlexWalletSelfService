using FlexWalletSelfService.Web.Abstractions.Models;
using FlexWalletSelfService.Web.Abstractions.Services.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Web;

namespace FlexWalletSelfService.Web.Services.DataServices
{
    public class WalletTransactionDataServices : IWalletTransactionDataServices
    {
        readonly IHttpClientFactory httpClientFactory;
        StatusMessage statusMessage = new();
        ISession session;

        public WalletTransactionDataServices(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
           
        }

        public async Task<WalletUserAccount> Balance(string WallectAccountNumber, string token)
        {
            WalletUserAccount walletUserAccount = new();
            try
            {//
                
                var client = httpClientFactory.CreateClient();
                
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response = await client.GetAsync($"FundTransaction/GetWallectAccountBalanceByAccountNumber?wlletAccountNumber={WallectAccountNumber}");
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

        public async Task<StatusMessage> Transfer(WalletFundTransfer walletFundTransfer, string token)
        {
            try
            { 
                var client = httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var json = JsonConvert.SerializeObject(walletFundTransfer);
                HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("FundTransaction/FundTransfer", contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var responseModel = await response.Content.ReadAsAsync<ApiAuthResponseModel>();
                    statusMessage = responseModel.Data;
                }
            }
            catch (Exception ex)
            {

            }
            return statusMessage;
        }
    }
}
