using Admin_Management_of_Blacklisted_Items.DTOs;
using Admin_Management_of_Blacklisted_Items.DTOs.AuthDTO;
using Admin_Management_of_Blacklisted_Items.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Management_of_Blacklisted_Items.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;

        public AuthController(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            await _userService.RegisterAsync(model);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var token = await _userService.LoginAsync(model);
            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}
