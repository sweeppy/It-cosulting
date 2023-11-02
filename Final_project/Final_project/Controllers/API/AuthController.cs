using Final_project.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Final_project.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        SignInManager<User> _signInManager;
        UserManager<User> _userManager;
        public AuthController(SignInManager<User> SIM, UserManager<User> UM)
        {
            _signInManager = SIM;
            _userManager = UM;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin model)
        {
            if (await IsValidUser(model.LoginProp, model.Password))
            {
                var token = GenerateToken(model.LoginProp);
                return Ok(new {token});
            }
            else
            {
                return Unauthorized();
            }
        }

        private async Task<bool> IsValidUser(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var isValidPassword = await _userManager.CheckPasswordAsync(user, password);
                return isValidPassword;
            }
            return false;
        }

        private string GenerateToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("mysupersecret_secretkey!123"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] { new Claim(ClaimTypes.NameIdentifier, username) };
            var token = new JwtSecurityToken(
                issuer: "xxx",
                audience: "yyy",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1), // Время жизни токена(сделано 1 мин для тестов)
                signingCredentials: credentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return tokenString;
           
        }
    }
}
