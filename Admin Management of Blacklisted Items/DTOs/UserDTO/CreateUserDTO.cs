namespace Admin_Management_of_Blacklisted_Items.DTOs.UserDTO
{
    public class CreateUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
