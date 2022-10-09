using FlexWalletSelfService.Web.Abstractions.Models;

namespace FlexWalletSelfService.Web.Abstractions.Services.Business
{
    public interface IWalletTransactionServices
    {
        Task<StatusMessage> FundTransfer(WalletFundTransfer walletFundTransferDto);
        Task<WalletUserAccount> GetAccountBalance(string WallectAccountNumber);
    }
}
