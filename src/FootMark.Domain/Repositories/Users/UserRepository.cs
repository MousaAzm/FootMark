using FootMark.Core.Entities.Users;
using FootMark.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Domain.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly FootMarkDbContext _context;

        public UserRepository(FootMarkDbContext context)
        {
            _context = context;
        }

        public string ErrorMessage { get; private set; }

        public async Task<bool> Add(AppUser user)
        {
            try
            {
                await _context.AppUsers.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var result = await _context.AppUsers.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.AppUsers.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public async Task<List<AppUser>> GetAll()
        {
            var result = await _context.AppUsers.ToListAsync();
            return result;
        }

        public async Task<AppUser> GetById(string id)
        {
            var result = await _context.AppUsers.Where(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update(AppUser user)
        {
            try
            {
                _context.AppUsers.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
    }
}
