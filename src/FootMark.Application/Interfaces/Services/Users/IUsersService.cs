using FootMark.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Application.Interfaces.Services.Users
{
    public interface IUsersService
    {
        Task<IEnumerable<AppUser>> GetUsersListAsync();
        Task<AppUser> GetUserAsync(string id);
        Task<bool> CreateUserAsync(AppUser requst);
    }
}
