using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AirlineCompanyWebAPI.Services;
using AirlineCompanyAPI.Models.DTOs;
using AirlineCompanyWebAPI.Models;

namespace AirlineCompanyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly LoginService _loginService;

        public LoginController(IConfiguration config)
        {
            _config = config;
            _loginService = new LoginService(); // Replace with DI in production
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginDTO userLogin)
        {
            var user = _loginService.Authenticate(userLogin);

            if (user != null)
            {
                var token = GenerateJwtToken(user);
                return Ok(new { token });
            }

            return Unauthorized("Invalid username or password.");
        }

        private string GenerateJwtToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username) // Only include the username
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
