using Admin_Management_of_Blacklisted_Items.DTOs.AuthDTO;
using Admin_Management_of_Blacklisted_Items.DTOs.UserDTO;
using Admin_Management_of_Blacklisted_Items.Models;
using Admin_Management_of_Blacklisted_Items.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin_Management_of_Blacklisted_Items.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = new PasswordHasher<User>();
            _tokenService = tokenService;
        }

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            // Verify the entered password against the hashed password
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, enteredPassword);
            return result == PasswordVerificationResult.Success;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<User> CreateUserAsync(string email, string password, List<string> roles)
        {
            var user = new User { Email = email };

            // Hash the password before storing it
            user.Password = _passwordHasher.HashPassword(user, password);

            user.Role = roles.Count > 0 ? roles[0] : null; // Assign the first role, if any

            var createdUser = await _userRepository.CreateUserAsync(user);
            return createdUser;
        }

        public async Task<User> UpdateUserAsync(int userId, UpdateUserDTO dto)
        {
            return await _userRepository.UpdateUserAsync(userId, dto);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task RegisterAsync(RegisterDto model)
        {
            // Validate model
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            // Check if the user already exists
            var existingUser = await _userRepository.GetUserByEmailAsync(model.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this email already exists.");
            }

            // Create a new user entity and hash the password
            var newUser = new User
            {
                Email = model.Email,
                Password = _passwordHasher.HashPassword(null, model.Password), // Hash the password
                Role = model.Role // Assuming the model contains the user's role
            };

            // Save the new user to the database
            await _userRepository.CreateUserAsync(newUser);
        }

        public async Task<string> LoginAsync(LoginDto model)
        {
            // Validate model
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            // Retrieve user by email
            var user = await _userRepository.GetUserByEmailAsync(model.Email);
            if (user == null)
            {
                // User not found, return null (authentication failed)
                return null;
            }

            // Validate password
            bool isPasswordValid = VerifyPassword(model.Password, user.Password);
            if (!isPasswordValid)
            {
                // Password is incorrect, return null (authentication failed)
                return null;
            }

            // Generate JWT token
            var roles = new List<string> { user.Role }; // Assuming the user has a single role
            var token = await _tokenService.CreateAccessTokenAsync(user.Email, roles, DateTime.UtcNow.AddHours(1));
            return token;
        }
    }
}
