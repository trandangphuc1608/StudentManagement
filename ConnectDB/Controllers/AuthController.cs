using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConnectDB.Data;
using ConnectDB.Models;
using ConnectDB.DTOs;

namespace ConnectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            // 1. Kiểm tra email trùng lặp
            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return BadRequest("Email này đã được sử dụng.");
            }

            // 2. Mã hóa mật khẩu
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // 3. Lưu vào Database
            var newUser = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                Name = request.Name,
                Roles = "Customer",
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đăng ký thành công!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            // 1. Tìm user theo Email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !user.IsActive)
            {
                return Unauthorized("Email hoặc mật khẩu không chính xác.");
            }

            // 2. Kiểm tra mật khẩu
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                return Unauthorized("Email hoặc mật khẩu không chính xác.");
            }

            // 3. Tạo JWT Token
            var token = GenerateJwtToken(user);

            return Ok(new
            {
                token = token,
                user = new { id = user.Id, name = user.Name, email = user.Email, role = user.Roles }
            });
        }

        private string GenerateJwtToken(User user)
        {
            var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is missing");
            var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
            var key = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Roles ?? "Customer"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2), // Token có thời hạn 2 tiếng
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}