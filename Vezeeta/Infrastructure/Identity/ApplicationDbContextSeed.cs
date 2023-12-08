using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Vezeeta.Infrastructure.Identity;

namespace Vezeeta.Infrastructure.Identity
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRolesAsync(roleManager);
            await SeedDefaultUserAsync(userManager);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

        }

        private static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "admin@vezeeta.com",
                Email = "admin@vezeeta.com",
                FirstName = "Admin",
                LastName = "User",
                Phone = "01010102020",
                
            };

            var existingUser = await userManager.FindByEmailAsync(defaultUser.Email);
            if (existingUser == null)
            {
                var result = await userManager.CreateAsync(defaultUser, "YourPasswordHere");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                }
                else
                {
                    throw new Exception("Failed to create the default user.");
                }
            }
        }
    }
}
