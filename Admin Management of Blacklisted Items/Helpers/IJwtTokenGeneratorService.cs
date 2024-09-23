using Admin_Management_of_Blacklisted_Items.Models;

namespace Admin_Management_of_Blacklisted_Items.Helpers
{
    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(User User, IEnumerable<string> roles, DateTime expiration);
    }
}
