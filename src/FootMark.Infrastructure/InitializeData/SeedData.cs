using FootMark.Domain.Models.Users;
using FootMark.Infrastructure.Contexts;
using System;

namespace FootMark.Infrastructure.InitializeData
{
    public static class SeedData
    {
        public static void Seeding(FootMarkDbContext context)
        {
            Seed(context);
        }

        private static void Seed(FootMarkDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var users = new AppUser[]
            {
                new AppUser{Id = Guid.NewGuid(), Name = "user_4", Email = "user_4@gmail.com", CreateDate = DateTime.Now},
                new AppUser{Id = Guid.NewGuid(), Name = "user_3", Email = "user_3@gmail.com", CreateDate = DateTime.Now},
                new AppUser{Id = Guid.NewGuid(), Name = "user_2", Email = "user_2@gmail.com", CreateDate = DateTime.Now},
                new AppUser{Id = Guid.NewGuid(), Name = "user_1", Email = "user_1@gmail.com", CreateDate = DateTime.Now},
            };

            context.AddRange(users);
            context.SaveChanges();

        }
    }
}