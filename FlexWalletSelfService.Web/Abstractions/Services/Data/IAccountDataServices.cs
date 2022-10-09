using FlexWalletSelfService.Web.Abstractions.Models;

namespace FlexWalletSelfService.Web.Abstractions.Services.Data
{
    public interface IAccountDataServices
    {
        Task<StatusMessage> Registration(WalletUserRegister walletUserRegister);
        Task<StatusMessage> Login(WalletUserLogin walletUserLogin);
    }
}
