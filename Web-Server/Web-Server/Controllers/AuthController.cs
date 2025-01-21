using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Server.Context;
using Web_Server.Jwt;
using Web_Server.Models;

namespace Web_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly JwtService _jwtService;

        public AuthController(PasswordHasher<User> passwordHasher, JwtService jwtService)
        {
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher)); // Проверка на null
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService)); // Проверка на null
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(UserDto user)
        {
            try
            {
                using (var db = new Test11234Context())
                {
                    var existingUser = await db.Users.FirstOrDefaultAsync(u => u.Name == user.Name);

                    if (existingUser == null)
                    {
                        return StatusCode(404, "Данные пользователя не найдены.");
                    }

                    var result = _passwordHasher.VerifyHashedPassword(existingUser, existingUser.Password, user.Password);

                    if (result == PasswordVerificationResult.Failed)
                    {
                        return StatusCode(403, "Неверные учетные данные.");
                    }

                    var token = _jwtService.GenerateToken(user.Name);
                    return Ok(new { Token = token });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, "Неверный формат запроса: {0}" + ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            // Проверяем, если пользователь с таким username уже существует 
            using (var db = new Test11234Context())
            {
                var existingUser = await db.Users.FirstOrDefaultAsync(u => u.Name == userDto.Name);

                if (existingUser != null)
                {
                    return BadRequest("Пользователь с таким именем уже существует.");
                }

                // Хеширование пароля
                var user = new User
                {
                    Name = userDto.Name,
                    Password = _passwordHasher.HashPassword(null, userDto.Password),
                };

                // Добавление пользователя в базу данных
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }
            return Ok("Пользователь успешно зарегистрирован.");
        }

        public class UserDto
        {
            public string Name { get; set; }
            public string Password { get; set; }
        }
    }
}
