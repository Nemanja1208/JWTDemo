using JWTDemo.Models;
using Microsoft.AspNetCore.Identity;

namespace JWTDemo.Data
{
    public class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            // Get services from DI
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            AppDbContext context =
                serviceProvider.GetRequiredService<AppDbContext>();

            // ===== SEED ROLES =====
            string[] roles = { "Admin", "User", "NemoSuperAdmin" };

            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // ===== SEED USERS =====
            if (await userManager.FindByEmailAsync("admin@jwtdemo.com") == null)
            {
                User admin = new User
                {
                    FirstName = "Admin",
                    LastName = "AdminLastName",
                    UserName = "admin",
                    Email = "admin@jwtdemo.com",
                    EmailConfirmed = true
                };

                IdentityResult result = await userManager.CreateAsync(admin, "Admin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            if (await userManager.FindByEmailAsync("user@jwtdemo.com") == null)
            {
                User regularUser = new User
                {
                    FirstName= "User",
                    LastName= "UserLastName",
                    UserName = "user",
                    Email = "user@jwtdemo.com",
                    EmailConfirmed = true
                };

                IdentityResult result = await userManager.CreateAsync(regularUser, "User123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(regularUser, "User");
                }
            }

            if (await userManager.FindByEmailAsync("nemo@jwtdemo.com") == null)
            {
                User sensei = new User
                {
                    FirstName = "Nemo",
                    LastName = "Sensei",
                    UserName = "nemo",
                    Email = "nemo@jwtdemo.com",
                    EmailConfirmed = true
                };

                IdentityResult result = await userManager.CreateAsync(sensei, "Sensei123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(sensei, "Admin");
                    await userManager.AddToRoleAsync(sensei, "NemoSuperAdmin");
                }
            }

            // ===== SEED DOGS =====
            if (!context.Dogs.Any())
            {
                List<Dog> dogs = new List<Dog>
            {
                new Dog { Id="1",Name = "Rex", Breed = "German Shepherd", Age = 3 },
                new Dog { Id="2",Name = "Bella", Breed = "Golden Retriever", Age = 5 },
                new Dog { Id="3",Name = "Max", Breed = "Labrador", Age = 2 },
                new Dog { Id="4",Name = "Luna", Breed = "Siberian Husky", Age = 4 },
                new Dog { Id="5",Name = "Rocky", Breed = "Rottweiler", Age = 6 },
                new Dog { Id="6",Name = "Molly", Breed = "Beagle", Age = 1 },
                new Dog { Id="7",Name = "Bruno", Breed = "Boxer", Age = 3 },
                new Dog { Id="8",Name = "Saga", Breed = "Swedish Vallhund", Age = 2 }
            };

                await context.Dogs.AddRangeAsync(dogs);
                await context.SaveChangesAsync();
            }
        }
    }
}
