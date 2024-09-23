using Admin_Management_of_Blacklisted_Items.DTOs.AuthDTO;
using Admin_Management_of_Blacklisted_Items.DTOs.UserDTO;
using Admin_Management_of_Blacklisted_Items.Models;

namespace Admin_Management_of_Blacklisted_Items.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(string email, string password, List<string> roles);
        Task<User> UpdateUserAsync(int userId, UpdateUserDTO dto);
        Task DeleteUserAsync(int userId);

        Task RegisterAsync(RegisterDto model);
        Task<string> LoginAsync(LoginDto model);

    }

}
