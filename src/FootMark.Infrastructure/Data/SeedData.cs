using FootMark.Core.Entities.Users;
using FootMark.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seeding(FootMarkDbContext context,
           UserManager<AppUser> userManager,
           RoleManager<IdentityRole> roleManager)
        {
            SeedProdects(context);
            SeedRoles(roleManager);
            SeedCustomers(userManager);
        }

        private static void SeedProdects(FootMarkDbContext context)
        {

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole adminRole = new IdentityRole();
                adminRole.Name = "Admin";
                IdentityResult roleResult1 = roleManager.
                CreateAsync(adminRole).Result;
            }

            if (!roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole organizerRole = new IdentityRole();
                organizerRole.Name = "Member";
                IdentityResult roleResult2 = roleManager.
                CreateAsync(organizerRole).Result;
            }

        }

        private static void SeedCustomers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                AppUser admin = new AppUser();
                admin.FirstName = "Mousa";
                admin.LastName = "Azimi";
                admin.UserName = "admin@gmail.com";
                admin.Email = "admin@gmail.com";

                IdentityResult result = userManager.CreateAsync(admin, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, "Admin").Wait();
                }

                AppUser user = new AppUser();
                user.FirstName = "Björn";
                user.LastName = "Strömberg";
                user.UserName = "hej@gmail.com";
                user.Email = "hej@gmail.com";

                IdentityResult result2 = userManager.CreateAsync(user, "/6vQd6USL,i_wB&").Result;
            }
        }
    }
}
