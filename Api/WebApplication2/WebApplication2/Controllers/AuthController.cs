using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Jwt;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/v1/SignIn")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly JwtService _jwtService;


        public AuthController(PasswordHasher<User> passwordHasher, JwtService jwtService)
        {
            this._passwordHasher = passwordHasher ?? throw new ArgumentException(nameof(_passwordHasher));
            this._jwtService = jwtService ?? throw new ArgumentException(nameof(jwtService));
        }

        // Запрос для входа в систему
        [HttpGet("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserDto user)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    // Поиск пользователя по имени 
                    var existingUser = await db.Users.FirstOrDefaultAsync(c => c.Name == user.name);
                    if (existingUser == null)
                    {
                        return StatusCode(404, "Пользователь не найден");
                    }

                    // Проверка хеша
                    var result = _passwordHasher.VerifyHashedPassword(existingUser, existingUser.Password, user.password);
                    if (result == PasswordVerificationResult.Failed)
                    {
                        return StatusCode(404, "Данные пользователя не найдены");
                    }

                    // Генерация токена
                    var token = _jwtService.GenerateToken(user.name);
                    return Ok(new { Token = token });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, "Неверный формат запроса {0}" + ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var existingUser = await db.Users.FirstOrDefaultAsync(c => c.Name == userDto.name);
                    if (existingUser != null)
                    {
                        return BadRequest("Пользователь с таким именем уже существует");
                    }

                    // Создание хеша
                    var user = new User()
                    {
                        Name = userDto.name,
                        Password = _passwordHasher.HashPassword(null, userDto.password),
                    };

                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();
                };

                {
                    return Ok("Пользователь успешно зарегистриован");
                }
            }
            catch (Exception)
            {
                return BadRequest("Не получилось");
            }
        }
    }


    public class UserDto
    {
        public string name { get; set; }
        public string password { get; set; }
    }
}
