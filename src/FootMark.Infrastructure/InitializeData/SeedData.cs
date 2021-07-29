using FootMark.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}