using FlexWalletSelfService.Web.Abstractions.Models;
using FlexWalletSelfService.Web.Abstractions.Services.Business;
using FlexWalletSelfService.Web.Abstractions.Services.Data;

namespace FlexWalletSelfService.Web.Services.BusinessServices
{
    public class WalletTransactionServices : IWalletTransactionServices
    {
        readonly IWalletTransactionDataServices walletTransactionDataServices;

        public WalletTransactionServices(IWalletTransactionDataServices walletTransactionDataServices)
        {
            this.walletTransactionDataServices = walletTransactionDataServices ?? throw new ArgumentNullException(nameof(walletTransactionDataServices));
        }

        public async Task<StatusMessage> FundTransfer(WalletFundTransfer walletFundTransfer)
        {
            return await this.walletTransactionDataServices.Transfer(walletFundTransfer);
        }

        public async Task<WalletUserAccount> GetAccountBalance(string WallectAccountNumber)
        {
            return await this.walletTransactionDataServices.Balance(WallectAccountNumber);
        }
    }
}
