using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1.Jwt
{
    public class JwtService
    {
        // Метод генерации токена Jwt токена на основе имени пользователя
        private readonly string _secretkey = "YOUR_32_BYTE_LONG_SECRET_KEY_BASE64";


        // Метод генерации Jwt токена на основе имени пользователя

        public string GenerateToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
            };

            // Создание симметричного ключа на основе секретного ключа
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretkey));

            // Настройка учетных данных для подписи токена с использованием HmacSha256
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Создание Jwt токена с заданными параметрами

            var token = new JwtSecurityToken(
                issuer: "yourapp",      // Автор токена
                audience: "yourapp",    // Пользователи для которых создан этот токен
                claims: claims,         // Утверждения, связанные с пользователем
                expires: DateTime.Now.AddHours(1), // Срок жизни токена
                signingCredentials: creds // Учетные данные для подписи токена
                );

            // Возвращает JWT токена
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
