using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication2.Jwt
{
    public class JwtService
    {
        // Создание секретного ключа
        private readonly string _secretKey = "YOUR_32_BYTE_LONG_SECRET_KEY_BASE64";

        // Генерация токена на основе имени пользователя
        public string GenerateToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
            };

            // Создание симметричного ключа на основе секретного ключа
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(username));

            // Настройка генерации с помощью HmacSha256
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Создание Jwt токена
            var token = new JwtSecurityToken(
                issuer: "yourapp",      // Создатель/автор  токена
                audience: "yourapp",    // Пользователи для которых создан этот токен
                claims: claims,         // Утверждения, связанные с именем пользователя
                expires: DateTime.Now.AddHours(1), // Срок жизни токена
                signingCredentials: creds);    // Учетные данные для подписи токена


            return new JwtSecurityTokenHandler().WriteToken(token);
        } 
    }
}
