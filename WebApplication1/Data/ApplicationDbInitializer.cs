using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager, ApplicationDbContext context)
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
                    context.Customers.Add(new Customer()
                    {
                        FNameHira = "佐助",
                        LNameKata = "内は",
                        FNameKata = "サスケ",
                        LNameHira = "ウチハ",
                        Phone = "093847893",
                        DateOfBirth = DateTime.Now,
                        Address = "〒103-0011 東京都中央区日本橋大伝馬町１１−８ ＨＡＴビル 3F ERAS株式会社",
                        UserId = user.Id
                    });
                    context.SaveChanges();
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
                    context.Customers.Add(new Customer()
                    {
                        FNameHira = "鳴門",
                        LNameKata = "うじゅ巻き",
                        FNameKata = "ナルト",
                        LNameHira = "ウジュマキ",
                        Phone = "093847893",
                        DateOfBirth = DateTime.Now,
                        Address = "〒103-0011 東京都中央区日本橋大伝馬町１１−８ ＨＡＴビル 3F ERAS株式会社",
                        UserId = user.Id
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
