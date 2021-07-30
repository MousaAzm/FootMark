using FootMark.Domain.Interfaces;
using FootMark.Domain.Models.Users;
using FootMark.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootMark.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {

        protected readonly FootMarkDbContext _context;
        protected readonly DbSet<AppUser> _dbSet;

        public UserRepository(FootMarkDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<AppUser>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<AppUser> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<AppUser> GetByEmail(string email)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }

        public void Add(AppUser user)
        {
            _dbSet.Add(user);
        }

        public void Update(AppUser user)
        {
            _dbSet.Update(user);
        }

        public void Remove(AppUser user)
        {
            _dbSet.Remove(user);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
