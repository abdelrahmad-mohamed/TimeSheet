using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace GlobalBrands.TimeSheet.DAL.Seeding
{

        public static class ApplicationDbContextSeed
        {
            public static async Task SeedUsersAndRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
            {
                // Roles

                if (!await roleManager.RoleExistsAsync("Employee"))
                    await roleManager.CreateAsync(new IdentityRole("Employee"));

                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));

                // Users
                var users = new List<(string UserName, string Password, string Role)>
            {
                ("Admin", "Admin2003#", "Admin")
            };

                foreach (var (userName, password, role) in users)
                {
                    if (await userManager.FindByNameAsync(userName) == null)
                    {
                        var user = new User
                        {
                            UserName = userName,
                            Email = $"{userName}@test.com",
                            EmailConfirmed = true,

                        };

                        var result = await userManager.CreateAsync(user, password);

                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, role);

                        }

                    }

                }
            }
        }
    }


