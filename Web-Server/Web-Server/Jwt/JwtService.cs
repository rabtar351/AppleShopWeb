using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Web_Server.Jwt
{
    public class JwtService
    {
        private readonly string _secretkey = "YOUR_32_BYTE_LONG_SECRET_KEY_BASE64";

        public string GenerateToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretkey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourapp",
                audience: "yourapp",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
