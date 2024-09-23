namespace Admin_Management_of_Blacklisted_Items.Services
{
    public interface ITokenService
    {
        Task<string> CreateAccessTokenAsync(string email, List<string> roles, DateTime expiration);
    }
}
