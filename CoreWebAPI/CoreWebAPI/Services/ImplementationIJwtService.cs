using CoreWebAPI.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoreWebAPI.Services
{
    public class ImplementationIJwtService : IJwtService
    {
        private readonly string key;

        public ImplementationIJwtService(string key)
        {
            this.key = key;
        }
        private readonly IDictionary<string, string> users = new Dictionary<string, string>()
        {
            {"user1","password1" },{ "user2","password2"}
        };

        public string Authentication(string username, string password)
        {
            var tokenHandler= new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenkey),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
