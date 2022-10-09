using FlexWalletSelfService.Web.Abstractions.Models;

namespace FlexWalletSelfService.Web.Abstractions.Services.Business
{
    public interface IAccountServices
    {
        Task<StatusMessage> WalletRegistration(WalletUserRegister walletUserRegister);
        Task<StatusMessage> WalletLogin(WalletUserLogin walletUserLogin);
    }
}
