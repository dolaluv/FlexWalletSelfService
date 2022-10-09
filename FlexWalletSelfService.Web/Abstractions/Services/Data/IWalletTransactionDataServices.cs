using FlexWalletSelfService.Web.Abstractions.Models;

namespace FlexWalletSelfService.Web.Abstractions.Services.Data
{
    public interface IWalletTransactionDataServices
    {
        Task<StatusMessage> Transfer(WalletFundTransfer  walletFundTransfer);
        Task<WalletUserAccount> Balance(string WallectAccountNumber);
    }
}
