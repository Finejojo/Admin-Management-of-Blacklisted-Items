using Microsoft.IdentityModel.Tokens;
using static Admin_Management_of_Blacklisted_Items.Helpers.JwtTokenGeneratorService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Admin_Management_of_Blacklisted_Items.Models;

namespace Admin_Management_of_Blacklisted_Items.Helpers
{
    public class JwtTokenGeneratorService : IJwtTokenGeneratorService
    {
        private readonly IConfiguration _config;

        public JwtTokenGeneratorService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(User user, IEnumerable<string> roles, DateTime expiration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value);

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    }

