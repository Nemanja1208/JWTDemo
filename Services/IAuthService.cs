using JWTDemo.Models;
using System.IdentityModel.Tokens.Jwt;

namespace JWTDemo.Services
{
    public interface IAuthService
    {
        public Task<string> LoginUser(UserLoginOrRegisterCredentials userDto);

        public string RegisterUser(UserLoginOrRegisterCredentials userDto);
    }
}
