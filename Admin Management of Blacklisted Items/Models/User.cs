using Microsoft.AspNetCore.Identity;
using System.Data;

namespace Admin_Management_of_Blacklisted_Items.Models
{
    public class User : IdentityUser
    {
        public new int Id { get; set; }
        public new string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
