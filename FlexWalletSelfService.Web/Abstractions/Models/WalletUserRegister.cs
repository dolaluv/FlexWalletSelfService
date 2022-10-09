using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FlexWalletSelfService.Web.Abstractions.Models
{
    public class WalletUserRegister
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

    }
}
