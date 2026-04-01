using JWTDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWTDemo.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        // CONSTRUCTOR
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DBSETS - TABELER

        // Detta User tabellen kommer ersättas av IdentityDbContext som redan har en User tabell, så vi behöver inte definiera den här.
        //public DbSet<User> Users { get; set; }
        public DbSet<Dog> Dogs { get; set; }


        // on model creating
    }
}
