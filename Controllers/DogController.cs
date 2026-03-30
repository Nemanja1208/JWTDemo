using JWTDemo.Models;
using JWTDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        // CRUD med DOGS
        private readonly IDogService dogService;

        public DogController(IDogService dogService)
        {
            this.dogService = dogService;
        }

        // get all dogs
        [Authorize]
        [HttpGet]
        public List<Dog> GetAllDogsFromDB()
        {
            return dogService.GetDogs();
        }


    }
}
