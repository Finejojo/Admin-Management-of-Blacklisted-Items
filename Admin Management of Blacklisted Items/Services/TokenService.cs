using Admin_Management_of_Blacklisted_Items.Helpers;
using Admin_Management_of_Blacklisted_Items.Models;

namespace Admin_Management_of_Blacklisted_Items.Services
{
    public class TokenService : ITokenService
    {
        private readonly IJwtTokenGeneratorService _jwtTokenGenerator;

        public TokenService(IJwtTokenGeneratorService jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> CreateAccessTokenAsync(string email, List<string> roles, DateTime expiration)
        {
            // Generate JWT token here
            var user = new User { Email = email }; // Retrieve user details as needed
            var token = _jwtTokenGenerator.GenerateToken(user, roles, expiration);
            return await Task.FromResult(token); // Simulate async operation
        }
    }

}
