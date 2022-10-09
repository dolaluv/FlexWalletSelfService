using System.Net;

namespace FlexWalletSelfService.Web.Abstractions.Models
{
    public class ApiAuthResponseModel
    { 
        public bool IsSuccess { get; set; } = true;
        public StatusMessage Data { get; set; }
        public string Message { get; set; } = "";
    }
   
}
