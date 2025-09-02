using Authentication.Data;
using Authentication.Helpers;
using Authentication.Models;
using Authentication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthContext _context;
        private readonly JwtTokenService _jwt;

        public AuthController(AuthContext context, JwtTokenService jwt)
        {
            _context = context;
            _jwt = jwt;
        }


        [HttpPost("signup")]
        public IActionResult Signup([FromBody] SignupDto dto)
        {
            // 1️⃣ Check if username already exists
            if (_context.Users.Any(u => u.Username == dto.Username))
            {
                return BadRequest(new { message = "Username already exists" });
            }

            // 2️⃣ Get the role(s) from DB
            var roles = _context.Roles
                .Where(r => dto.RoleNames.Contains(r.Name))
                .ToList();

            if (!roles.Any())
            {
                return BadRequest(new { message = "Invalid roles provided" });
            }

            // 3️⃣ Create the new user
            var user = new User
            {
                Username = dto.Username,
                Password = PasswordHasher.HashPassword(dto.Password),
                Roles = roles
            };

            // 4️⃣ Save to DB
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = "User registered successfully" });
        }




        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _context.Users
                .Include(u => u.Roles)
                .FirstOrDefault(u => u.Username == dto.Username);

            if (user == null || !PasswordHasher.VerifyPassword(dto.Password, user.Password))
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            var roles = user.Roles.Select(r => r.Name).ToList();
            var token = _jwt.GenerateToken(user, roles);

            return Ok(new { token });
        }

    }
}
