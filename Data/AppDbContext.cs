using JWTDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTDemo.Data
{
    public class AppDbContext : DbContext
    {
        // CONSTRUCTOR
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DBSETS - TABELER
        public DbSet<User> Users { get; set; }
        public DbSet<Dog> Dogs { get; set; }


        // on model creating
    }
}
