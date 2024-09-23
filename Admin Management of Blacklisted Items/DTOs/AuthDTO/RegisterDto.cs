using System.ComponentModel.DataAnnotations;

namespace Admin_Management_of_Blacklisted_Items.DTOs.AuthDTO
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
