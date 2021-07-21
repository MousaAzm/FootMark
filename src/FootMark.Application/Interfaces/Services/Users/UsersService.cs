using FootMark.Core.Entities.Users;
using FootMark.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Application.Interfaces.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly FootMarkDbContext _context;
        
        public UsersService(FootMarkDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppUser>> GetUsersListAsync()
        {
            return await _context.AppUsers.ToListAsync();
        }

        public async Task<AppUser> GetUserAsync(string id)
        {
            return await _context.AppUsers.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> CreateUserAsync(AppUser user)
        {
            await _context.AppUsers.AddAsync(user);
            var createdRowCount = await _context.SaveChangesAsync();
            return createdRowCount > 0;
        }
    }
}
