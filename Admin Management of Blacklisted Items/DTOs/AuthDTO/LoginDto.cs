using System.ComponentModel.DataAnnotations;

namespace Admin_Management_of_Blacklisted_Items.DTOs.AuthDTO
{
    public class LoginDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
