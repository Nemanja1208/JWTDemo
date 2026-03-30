using JWTDemo.Models;
using System.IdentityModel.Tokens.Jwt;

namespace JWTDemo.Services
{
    public interface IAuthService
    {
        public string LoginUser(UserLoginOrRegisterCredentials userDto);

        public string RegisterUser(UserLoginOrRegisterCredentials userDto);
    }
}
