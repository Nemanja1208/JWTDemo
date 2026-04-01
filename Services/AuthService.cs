using JWTDemo.Data;
using JWTDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTDemo.Services
{
    public class AuthService : IAuthService
    {
        // Database
        private readonly UserManager<User> userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<User> _userMamanger, IConfiguration configuration)
        {
            userManager = _userMamanger;
            _configuration = configuration;
        }

        public async Task<string> LoginUser(UserLoginOrRegisterCredentials userDto)
        {
            // SAMMA LOGIK SOM VI HADE INNAN för LOGIN

            // Kollar om användaren finns i databasen med hjälp av username
            User user = await userManager.FindByNameAsync(userDto.Username);

            if(userManager.CheckPasswordAsync(user, userDto.Password).Result)
            {
                // Skapa JWT token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    // if we have a User that can have multiple roles, we need to loop through them and add them as claims
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName!),
                        new Claim(ClaimTypes.Role, userManager.GetRolesAsync(user).Result.FirstOrDefault()!),
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"])), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return "Something wrong with username or password";
        }

        public string RegisterUser(UserLoginOrRegisterCredentials userDto)
        {
            throw new NotImplementedException();
        }
    }
}
