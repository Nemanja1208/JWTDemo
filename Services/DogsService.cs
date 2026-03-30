using JWTDemo.Data;
using JWTDemo.Models;
using Microsoft.AspNetCore.Authorization;

namespace JWTDemo.Services
{
    public class DogsService : IDogService
    {
        // CRUD med DOGS ---- database
        private readonly AppDbContext database;

        public DogsService(AppDbContext dbContext)
        {
            database = dbContext;
        }
        public Dog CreateDog(Dog dog)
        {
            throw new NotImplementedException();
        }

        public Dog DeleteDog(int Id)
        {
            throw new NotImplementedException();
        }

        public Dog GetDogById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Dog> GetDogs()
        {
            return database.Dogs.ToList();
        }

        public Dog UpdateDog(Dog dog)
        {
            throw new NotImplementedException();
        }
    }
}
