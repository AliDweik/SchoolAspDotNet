using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School.Dtos.Auth;
using School.Models.AuthModels;
using School.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace School.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration config, IAuthService authService)
        {
            _config = config;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var user = await _authService.Login(request.Username, request.Password);

            if(user == null) {
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            foreach(var userRole in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(60),
                SigningCredentials = cred,
                Issuer = _config["JwtSettings:Issuer"],
                Audience = _config["JwtSettings:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);


            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user = new
                {
                    userName = user.Username,
                    roles = user.UserRoles.Select(ur => ur.Role.Name).ToList()
                }
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            if (await _authService.UserExists(request.Username))
                return BadRequest("Username already Exists");
            var userToCreate = new User
            {
                Username = request.Username
            };

            var createdUser = await _authService.Register(userToCreate, request.Password);
            return StatusCode(201);
        }



    }
}
