using FootMark.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Infrastructure.Contexts
{
    public class  FootMarkDbContext : DbContext
    {
        public FootMarkDbContext(DbContextOptions<FootMarkDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
