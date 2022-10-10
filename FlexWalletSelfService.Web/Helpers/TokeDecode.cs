using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using static System.Formats.Asn1.AsnWriter;

namespace FlexWalletSelfService.Web.Helpers
{
    public static class TokeDecode
    {
        public static TokenPayLoad ProcessToken(string permissionJwt)
        { 

            TokenPayLoad tokenPayLoad = null;
            if(permissionJwt == null)
                return tokenPayLoad;

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(permissionJwt);
                if (token.ValidTo < DateTime.UtcNow)
                    return tokenPayLoad;
                var authorizationClaim = token.Claims.FirstOrDefault(claim => claim.Type.Equals("user", StringComparison.OrdinalIgnoreCase))?.Value;
                if (authorizationClaim != null)
                {
                    tokenPayLoad = JsonConvert.DeserializeObject<TokenPayLoad>(authorizationClaim);
                     

                }
                

            }
            catch { throw; }
            return tokenPayLoad;
        }
        
    }
    public class TokenPayLoad
    {
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }

}
