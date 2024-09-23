namespace Admin_Management_of_Blacklisted_Items.DTOs.UserDTO
{
    public class UpdateUserDTO
    {
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
