using Admin_Management_of_Blacklisted_Items.DTOs.AuthDTO;

namespace Admin_Management_of_Blacklisted_Items.Services
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(RegisterDto registerDTO, List<string> roles);
        Task<string> LoginAsync(LoginDto loginDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
