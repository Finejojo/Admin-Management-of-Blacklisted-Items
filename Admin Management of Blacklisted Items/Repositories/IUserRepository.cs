using Admin_Management_of_Blacklisted_Items.DTOs.UserDTO;
using Admin_Management_of_Blacklisted_Items.Models;

namespace Admin_Management_of_Blacklisted_Items.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(int userId, UpdateUserDTO dto);
        Task DeleteUserAsync(int userId);
    }
}
