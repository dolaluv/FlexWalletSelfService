using FlexWalletSelfService.Web.Abstractions.Models;
using FlexWalletSelfService.Web.Abstractions.Services.Business;
using FlexWalletSelfService.Web.Abstractions.Services.Data;

namespace FlexWalletSelfService.Web.Services.BusinessServices
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountDataServices accountDataServices;

        public AccountServices(IAccountDataServices accountDataServices)
        {
            this.accountDataServices = accountDataServices ?? throw new ArgumentNullException(nameof(accountDataServices));
        }

        public async Task<StatusMessage> WalletLogin(WalletUserLogin walletUserLogin)
        {
            return await this.accountDataServices.Login(walletUserLogin);
        }

        public async Task<StatusMessage> WalletRegistration(WalletUserRegister walletUserRegister)
        {
            return await this.accountDataServices.Registration(walletUserRegister);
        }
    }
}
