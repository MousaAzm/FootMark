using FootMark.Application.Interfaces.Contexts;
using FootMark.Core.Entities.Users;
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
        private readonly IFootMarkDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UsersService(IFootMarkDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IEnumerable<UsersDto>> GetUsersToListAsync()
        {
            return await _context.AppUsers.Select(u => new UsersDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                City = u.City,
                Address = u.Address,
                State = u.State,
                Zip = u.Zip

            }).ToListAsync();

        }
    

        public async Task<UsersDto> EditUserAsync(UsersDto requst)
        {
            var user = await _context.AppUsers.FindAsync(requst.Id);

            user.FirstName = requst.FirstName;
            await _context.SaveChangesAsync();

            return requst;

        }

        public UsersDto GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
