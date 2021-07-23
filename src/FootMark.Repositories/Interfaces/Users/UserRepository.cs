using FootMark.Domain.Data.Contexts;
using FootMark.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Repositories.Interfaces.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly FootMarkDbContext _context;

        public UserRepository(FootMarkDbContext context)
        {
            _context = context;
        }

        public string ErrorMessage { get; private set; }

        public async Task<AppUser> Add(AppUser user)
        {
            await _context.AppUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<AppUser> Delete(string id)
        {
            var result = await _context.AppUsers.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.AppUsers.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
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

        public async Task<AppUser> Update(AppUser user)
        {
            var result = await _context.AppUsers.Where(e => e.Id == user.Id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.UserName = user.UserName;
                result.Email = user.Email;
                result.PhoneNumber = user.PhoneNumber;
                result.Address = user.Address;
                result.City = user.City;
                result.State = user.State;
                result.Zip = user.Zip;
                _context.AppUsers.Update(user);
                await _context.SaveChangesAsync();
            }
            return result;
        }
    }
}
