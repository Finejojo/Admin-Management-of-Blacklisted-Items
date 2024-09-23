using System;
using System.Collections.Generic;
using Admin_Management_of_Blacklisted_Items.Data;
using Admin_Management_of_Blacklisted_Items.DTOs.UserDTO;
using Admin_Management_of_Blacklisted_Items.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin_Management_of_Blacklisted_Items.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(int userId, UpdateUserDTO dto)
        {
            var existingUser = await _context.Users.FindAsync(userId);

            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            // Manually map DTO properties to the user entity
            existingUser.Email = dto.Email;
            existingUser.Role = dto.Roles.FirstOrDefault(); // Assuming a single role
            

            // Explicitly mark the entity as modified
            _context.Entry(existingUser).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

        }
    }
}