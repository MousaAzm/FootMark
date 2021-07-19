using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Application.Interfaces.Services.Users
{
    public interface IUsersService
    {
        Task<IEnumerable<UsersDto>> GetUsersToListAsync();
        UsersDto GetUserByIdAsync(string id);
        Task<UsersDto> EditUserAsync(UsersDto requst);
    }
}
