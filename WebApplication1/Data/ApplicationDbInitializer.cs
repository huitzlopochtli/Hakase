using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Data
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@hakase.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin@hakase.com",
                    Email = "admin@hakase.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "abcD123$").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync("customer1@hakase.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "customer1@hakase.com",
                    Email = "customer1@hakase.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "hakase.com").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Customer").Wait();
                }
            }

            if (userManager.FindByEmailAsync("customer2@hakase.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "customer2@hakase.com",
                    Email = "customer2@hakase.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "hakase.com").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Customer").Wait();
                }
            }
        }
    }
}
