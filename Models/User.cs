using Microsoft.AspNetCore.Identity;

namespace JWTDemo.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } 

        public string LastName { get; set; }

        // ROLE kommer inte att funka så - Identity har en separat tabell för roller och en relationstabell för att koppla användare till roller, så vi behöver inte ha en Role egenskap i User klassen.
        //public string Role { get; set; }
    }

    public class UserLoginOrRegisterCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
