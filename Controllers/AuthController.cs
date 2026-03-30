using JWTDemo.Models;
using JWTDemo.Services;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }

        // AUTH SERVICE - GENERERA JWT TOKEN OCH RETURNERA
        [HttpPost]
        public string Login(UserLoginOrRegisterCredentials userDto)
        {
            return authService.LoginUser(userDto);
        }
    }
}
