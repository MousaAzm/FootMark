using FootMark.Application.Interfaces.Contexts;
using FootMark.Core.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Infrastructure.Contexts
{
    public class FootMarkDbContext : IdentityDbContext<AppUser>, IFootMarkDbContext
    {
        public FootMarkDbContext(DbContextOptions<FootMarkDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
