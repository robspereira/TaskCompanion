using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoManager.DTO;
using ToDoManager.Interface;
using ToDoManager.Model;

namespace ToDoManager.Controller
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserAuthInterface authService) : ControllerBase
    {
        
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            var user = await authService.RegisterAsync(request);
            if (user == null)
                return BadRequest("Username already exists");
            
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDTO>> Login(UserDTO request)
        {
            var result = await authService.LoginAsync(request);
            if (result is null)
                return BadRequest("Invalid username or password");

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDTO>> RefreshToken(RefreshTokenRequestDTO request)
        {
            var result = await authService.RefreshTokenAsync(request);
            
            if(result is null || result.AccessToken == null || result.RefreshToken == null) 
                return Unauthorized("Invalid refresh token");
            
            return Ok(result);
        }
        
        [HttpGet("test")]
        [Authorize]
        public IActionResult AuthenticatedOnly()
        {
            return Ok();
        }
        
        [HttpGet("test")]
        [Authorize(Roles = "admin")]
        public IActionResult AuthenticatedAdminOnly()
        {
            return Ok("You are an admin!");
        }
        
    
    }
    
}

