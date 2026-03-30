using JWTDemo.Data;
using JWTDemo.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTDemo.Services
{
    public class AuthService : IAuthService
    {
        // Database
        private readonly AppDbContext database;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext database, IConfiguration configuration)
        {
            this.database = database;
            _configuration = configuration;
        }

        public string LoginUser(UserLoginOrRegisterCredentials userDto)
        {
            // Kollar om användaren finns i databasen med hjälp av username
            if (database.Users.Any(user => user.Username == userDto.Username))
            {
                var user = database.Users.First(user => user.Username == userDto.Username);
                if (user.Password == userDto.Password)
                {
                    // Skapa JWT token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Username),
                            new Claim(ClaimTypes.Role, user.Role),
                        }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"])), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }
            }
            return "Something wrong with username or password";
        }

        public string RegisterUser(UserLoginOrRegisterCredentials userDto)
        {
            throw new NotImplementedException();
        }
    }
}
