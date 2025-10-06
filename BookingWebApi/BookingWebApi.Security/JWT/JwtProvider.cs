using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingWebApi.BookingWebApi.Security.JWT
{
    public class JwtProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string secretKey = "vndkfnvlsdnvlsfdbvslsb632lisdfbvbayflb2426sdflvbsudfbvliusdfnvu2327ayb";

        public JwtProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateToken(Guid id, string role)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, id.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddHours(3)
            );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
