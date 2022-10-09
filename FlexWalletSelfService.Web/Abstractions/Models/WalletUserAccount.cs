using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWalletSelfService.Web.Abstractions.Models
{
    public class WalletUserAccount
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public double AccountBalance { get; set; }
    }
}
