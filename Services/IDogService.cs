using JWTDemo.Models;

namespace JWTDemo.Services
{
    public interface IDogService
    {
        public List<Dog> GetDogs();

        public Dog GetDogById(int Id);

        public Dog CreateDog(Dog dog);

        public Dog UpdateDog(Dog dog);

        public Dog DeleteDog(int Id);
    }
}
