using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace notelab.Helper
{
    public class Authentication
    {
        private IConfiguration _config;    
    
        public Authentication(IConfiguration config)    
        {    
            _config = config;    
        }
        public string GenAuthToken(string id)
        {    
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credential);
            var payload = new JwtPayload(id, null, null, null, DateTime.Today.AddDays(1));
            var secureToken = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(secureToken);  
        }
        public JwtSecurityToken TokenVerify(String token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }
            , out SecurityToken validatedToken);
            return (JwtSecurityToken)validatedToken;
        }
    }
}